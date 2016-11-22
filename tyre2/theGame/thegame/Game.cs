using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace thegame
{
    class Game
    {
        static BufferedGraphicsContext context;
        static public BufferedGraphics buffer;
        static BaseObject[] objs;
        static List<Asteroid> asteroids;
        static List<Bullet> bullets = new List<Bullet>();
        //static Image backGroundImage = Image.FromFile("space.jpg");
        static Ship ship = new Ship(new Point(10, 400), new Point(5, 5), new Size(50, 50));
        static int totalScores = 0;
        static Timer timer = new Timer();        
        public static Random rnd = new Random();
        static string logFile = "log.txt";
        static HealthKit heal;
        static int asteroidCount = rnd.Next(2, 10);

        static Game(){}

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
            form.KeyDown += Form_KeyDown;
            //обработчик события отпущена кнопка
            form.KeyUp += Form_KeyUp;
            //добавляем функцию для обработки события
            Ship.MessageDie += Finish;
            //form.BackgroundImage = backGroundImage;
            Log("Начинаем новую игру", true);
        }

        private static void Form_KeyUp(object sender, KeyEventArgs e)
        {
            ship.up = false;
            ship.down = false;
            ship.left = false;
            ship.right = false;
        }

        static private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.ControlKey:
                case Keys.Space:
                    bullets.Add(new Bullet(new Point(ship.Rect.X + 50, ship.Rect.Y + 25), new Point(20, 0), new Size(4, 1)));
                    break;
                case Keys.Up:
                case Keys.W:
                    ship.up = true;
                    ship.down = false;
                    break;
                case Keys.Down:
                case Keys.S:
                    ship.up = false;
                    ship.down = true;
                    break;
                case Keys.Left:
                case Keys.A:
                    ship.left = true;
                    ship.right = false;
                    break;
                case Keys.Right:
                case Keys.D:
                    ship.left = false;
                    ship.right = true;
                    break;
            }            
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
            foreach (Bullet bullet in bullets)
                if (bullet != null) bullet.Draw();
            if (heal != null) heal.Draw();
            ship.Draw();
            buffer.Graphics.DrawString("Energy:" + ship.Energy, SystemFonts.DefaultFont, Brushes.White, 0, 0);
            buffer.Graphics.DrawString("Game Scores:" + totalScores, SystemFonts.DefaultFont, Brushes.White, 100, 0);            
            buffer.Render();
        }
        static public void Update()
        {
            ship.Update();
            foreach (BaseObject obj in objs) obj.Update();
            
            if (heal != null) heal.Update();
            for (int b = 0; b < bullets.Count; b++)
            {
                if ((bullets[b] as Bullet).getPos().X >= Game.Width)
                {
                    bullets.Remove(bullets[b]);
                    continue;
                }

                bullets[b].Update();
            }
            //поверяем наличие астероидов.
            for (int i = 0; i < asteroids.Count; i++)            
                if (asteroids[i] == null)
                    asteroids.Remove(asteroids[i]);
            // если не осталось астероидов - генерируем    
            if (asteroids.Count == 0) 
            {
                asteroidCount++;
                asteroids = Asteroid.generateAsteroids(asteroidCount);
                Log("Влетаем в новый пояс астероидов");
            }

            //обход всех астероидов
            for (int i = 0; i < asteroids.Count; i++)
            {
                
                if (asteroids[i] != null)
                {
                    
                    asteroids[i].Update();
                    for(int b = 0; b< bullets.Count;b++)
                    {                                         
                        if (bullets[b] != null && asteroids[i] != null && bullets[b].Collision(asteroids[i]))
                        {
                            System.Media.SystemSounds.Hand.Play();
                            totalScores += asteroids[i].scoreIncrease;
                            asteroids[i] = null;
                            bullets.Remove(bullets[b]);
                            Log("Нашим доблестным экипажем корабля был уничтожен очередной астероид");
                            continue;
                        }

                        
                    }
                    if (ship.enable && asteroids[i]!= null && ship.Collision(asteroids[i]))
                    {
                        asteroids[i] = null;
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

            asteroids = Asteroid.generateAsteroids(asteroidCount);

        }

        static public void Finish()
        {
            //timer.Stop();           

            //TODO: не выводится
            //buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 200, 100);
            //buffer.Render();
            ship.enable = false;
            Log("Игра окончена, мы заработали " + totalScores + " очков");
            
        }

        static void Log(string message="сообщение", bool flush = false)
        {
            Console.WriteLine("{0}: {1}", DateTime.Now.ToShortTimeString(), message);
            StreamWriter writetext = new StreamWriter(logFile,!flush);
            writetext.WriteLine("{0}: {1}", DateTime.Now.ToShortTimeString(), message);
            writetext.Close();            
        }

    }
}
