using System;
using System.Drawing;

namespace thegame
{
    class Asteroid : BaseObject
    {
        static Image newImage = Image.FromFile("osteroid.png");
        public int scoreIncrease = 10;

        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {           
        }
                
        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(newImage, new Rectangle(new Point(pos.X, pos.Y),new Size(size.Width,size.Height)));
        }

        public override void Update()
        {
            pos.X += dir.X;
            if (pos.X < 0)
            {
                pos.X = Game.Width + 20;
                pos.Y = Game.rnd.Next(0, Game.Height);
            }

        }

        public override void Regenerate()
        {
            pos.X = Game.Width + size.Width;
            pos.Y = Game.rnd.Next(Game.Height);
        }
    }
}


