using System;
using System.Drawing;

namespace Asteroids
{
    class BaseObject
    {
        protected Point pos;
        protected Point dir;
        protected Size size;

        public BaseObject()
        {

        }

        public BaseObject(Point pos, Point dir, Size size)
        {
            this.pos = pos;
            this.dir = dir;
            this.size = size;
        }

        public virtual void Draw()
        {
            Game.buffer.Graphics.DrawEllipse(Pens.White, pos.X, pos.Y, size.Width, size.Height);
        }

        public virtual void Update()
        {
            pos.X = pos.X + dir.X;
            pos.Y = pos.Y + dir.Y;
            if (pos.X < 0 || pos.X > (Game.Width - size.Width)) dir.X = -dir.X;
            if (pos.Y < 0 || pos.Y > (Game.Height - size.Height)) dir.Y = -dir.Y;
        }
    }

    class Star: BaseObject
    {
        Color RandomColor;
        

        public Star(Point pos, Point dir, Size size, Color RandomColor) : base(pos, dir, size)
        {
            
            this.RandomColor = RandomColor;
        }

        public override void Update()
        {
            pos.X = pos.X + dir.X;
            if (pos.X < 0) pos.X = Game.Width + size.Width;
        }

        public override void Draw()
        {
            Game.buffer.Graphics.DrawLine(new Pen(RandomColor), pos.X, pos.Y, pos.X + size.Width, pos.Y + size.Height);
            Game.buffer.Graphics.DrawLine(new Pen(RandomColor), pos.X + size.Width, pos.Y, pos.X, pos.Y + size.Height);
        }
    }

    class Sun : BaseObject
    {
        public Sun(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }
        public override void Update()
        {
            pos.X = pos.X + dir.X;
            if (pos.X < 0) pos.X = Game.Width + size.Width;
        }

        public override void Draw()
        {
            // Create image.
            Image newImage = Image.FromFile("sun.png");
            

            // Draw image to screen.
            Game.buffer.Graphics.DrawImage(newImage, pos.X, pos.Y, 150, 150);
        }
    }
}
