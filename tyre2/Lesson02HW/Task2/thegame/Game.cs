using System;
using System.Drawing;
using System.Windows.Forms;

namespace thegame
{
    class Game
    {
        static BufferedGraphicsContext context;
        static public BufferedGraphics buffer;
        static BaseObject[] objc;
        static Asteroid[] asteroids;
        static Image newImage = Image.FromFile("space.jpg");
        static Bullet bullet;
        static public Random rnd = new Random();
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
            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Start();
            timer.Tick += Timer_Tick;
            
            
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Update();
            Draw();
            
        }

        static public void Draw()
        {
          //  buffer.Graphics.Clear(Color.Black);
            buffer.Graphics.DrawImage(newImage, new Point());
            //buffer.Graphics.DrawRectangle(Pens.Brown, new Rectangle(50, 50, 200, 200));
            //buffer.Graphics.FillEllipse(Brushes.Blue, new Rectangle(30, 20, 200, 200));
            foreach (BaseObject obj in objc)
                obj.Draw();
            foreach (Asteroid obj in asteroids)
                obj.Draw();
            bullet.Draw();
            buffer.Render();
        }

        static public void Update()
        {
            foreach (BaseObject obj in objc)
                obj.Update();

            foreach (Asteroid a in asteroids)
            {
                a.Update();
                if (a.Collision(bullet)) {                    
                    a.Regenerate();
                    bullet.Regenerate();
                }
            }

            bullet.Update();

        }
        static public void Load()
        {
            bullet = new Bullet(new Point(0, 200), new Point(5, 0), new Size(4, 1));

            objc = new BaseObject[10];
            for (int i = 0; i < objc.Length; i++)
                objc[i] = new Star(new Point(800, rnd.Next(Height)), new Point(rnd.Next(10, 15) - 15, 0), new Size(2, 2));

            asteroids = new Asteroid[10];
            for (int i = 0; i < asteroids.Length; i++)
                asteroids[i] = new Asteroid(new Point(800, rnd.Next(Height)), new Point(rnd.Next(0, 10)-15, 0), new Size(20, 20));

        }
    }
}
