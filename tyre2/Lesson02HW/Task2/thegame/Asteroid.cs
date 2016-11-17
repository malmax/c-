using System;
using System.Drawing;

namespace thegame
{
    class Asteroid : BaseObject
    {
        Image newImage = Image.FromFile("osteroid.png");

        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            //base.pos = pos;
            //base.dir = dir;
            //base.size = size;

        }



        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(newImage, new Point(pos.X, pos.Y));
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


