using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace thegame
{
    class Game
    {
        static BufferedGraphicsContext context;
        static public BufferedGraphics buffer;
        static BaseObject[] objs;
        static Asteroid[] asteroids;
        //static Image backGroundImage = Image.FromFile("space.jpg");
        static Bullet bullet;
        static Ship ship = new Ship(new Point(10, 400), new Point(5, 5), new Size(50, 50));        static int totalScores = 0;        static Timer timer = new Timer();        
        public static Random rnd = new Random();        static string logFile = "log.txt";        static HealthKit heal;
        //static Game(){}

        static public int Width { get; set; }
        static public int Height { get; set; }

        static public void Init(Form form)
        {
            
            Graphics g = form.CreateGraphics();
            context = BufferedGraphicsManager.Current;

            Width = form.Width;
            Height = form.Height;
            if(Width >1000 || Height > 1000 || Width <=0 || Height <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            buffer = context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();
           
            timer.Interval = 100;
            timer.Start();
            timer.Tick += Timer_Tick;
            //обработчик события Нажата кнопка
            form.KeyDown += Form_KeyDown;            //добавляем функцию для обработки события            Ship.MessageDie += Finish;            //form.BackgroundImage = backGroundImage;
            Log("Начинаем новую игру", true);
        }

        static private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey) bullet = new Bullet(new Point(ship.Rect.X + 50, ship.Rect.Y + 25), new Point(20, 0), new Size(4, 1));
            if (e.KeyCode == Keys.Up) ship.Up();
            if (e.KeyCode == Keys.Down) ship.Down();
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Update();
            Draw();            
        }        

        static public void Draw()
        {
            buffer.Graphics.Clear(Color.Transparent);
            foreach (BaseObject obj in objs)
                obj.Draw();
            foreach (Asteroid a in asteroids)
                if (a != null) a.Draw();
            if (bullet != null) bullet.Draw();
            if (heal != null) heal.Draw();
            ship.Draw();
            buffer.Graphics.DrawString("Energy:" + ship.Energy, SystemFonts.DefaultFont, Brushes.White, 0, 0);
            buffer.Graphics.DrawString("Game Scores:" + totalScores, SystemFonts.DefaultFont, Brushes.White, 100, 0);            
            buffer.Render();
        }
        static public void Update()
        {
            foreach (BaseObject obj in objs) obj.Update();
            if (bullet != null) bullet.Update();
            if (heal != null) heal.Update();
            for (int i = 0; i < asteroids.Length; i++)
            {
                if (asteroids[i] != null)
                {
                    asteroids[i].Update();
                    if (bullet != null && bullet.Collision(asteroids[i]))
                    {
                        System.Media.SystemSounds.Hand.Play();
                        asteroids[i].Regenerate();
                        totalScores += asteroids[i].scoreIncrease;
                        bullet = null;
                        Log("Нашим доблестным экипажем корабля был уничтожен очередной астероид");
                        continue;
                    }
                    if (ship.enable && ship.Collision(asteroids[i]))
                    {
                        asteroids[i].Regenerate();
                        ship.EnergyLow(rnd.Next(1, 10));
                        System.Media.SystemSounds.Asterisk.Play();
                        if (ship.Energy <= 0) ship.Die();

                        Log("Произошло столкновение корабля с астероидом");
                    }
                    if (heal != null && ship.Collision(heal))
                    {
                        heal.Regenerate();
                        ship.EnergyUp(heal.energyRestore);
                        System.Media.SystemSounds.Asterisk.Play();                        

                        Log("Мы успешно восстановилми корпус корабля на "+ heal.energyRestore + " единиц");
                    }
                }
            }
        }
    
        static public void Load()
        {
            heal = new HealthKit(new Point(rnd.Next(1,3)*Game.Width, rnd.Next(Game.Height)), new Point(-10, 0), new Size(30, 30));

            objs = new BaseObject[100];
            for (int i = 0; i < objs.Length; i++)
                objs[i] = new Star(new Point(rnd.Next(Width), rnd.Next(Height)), new Point(rnd.Next(14, 16) - 15, 0), new Size(1, 1));

            asteroids = new Asteroid[10];
            for (int i = 0; i < asteroids.Length; i++)
                asteroids[i] = new Asteroid(new Point(800, rnd.Next(Height)), new Point(rnd.Next(0, 10)-15, 0), new Size(50, 50));

        }

        static public void Finish()
        {
            //timer.Stop();           

            //TODO: не выводится
            //buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 200, 100);
            //buffer.Render();
            ship.enable = false;
            Log("Игра окончена, мы заработали " + totalScores + " очков");
            
        }        static void Log(string message="сообщение", bool flush = false)
        {
            Console.WriteLine("{0}: {1}", DateTime.Now.ToShortTimeString(), message);
            StreamWriter writetext = new StreamWriter(logFile,!flush);
            writetext.WriteLine("{0}: {1}", DateTime.Now.ToShortTimeString(), message);
            writetext.Close();            
        }
    }
}
