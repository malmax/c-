using System;
using System.Drawing;

namespace Asteroids
{
    class BaseObject
    {
        protected Point pos;
        protected Point dir;
        protected Size size;

        public BaseObject(Point pos, Point dir, Size size)
        {
            this.pos = pos;
            this.dir = dir;
            this.size = size;
        }

        public void Draw()
        {
            Game.buffer.Graphics.DrawEllipse(Pens.White, pos.X, pos.Y, size.Width, size.Height);
        }

        public void Update()
        {
            pos.X = pos.X + dir.X;
            pos.Y = pos.Y + dir.Y;
            if (pos.X < 0) dir.X = -dir.X;
            if(pos.X > Game.Width) dir.X = -dir.X;
        }
    }

    class Star: BaseObject
    {
        public void Draw()
        {
            pos.X = 10;
            pos.Y = 20;
        }
    }
}
