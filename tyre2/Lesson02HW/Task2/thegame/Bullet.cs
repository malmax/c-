using System;
using System.Drawing;

namespace thegame
{
    class Bullet: BaseObject
    {
        public Bullet(Point pos, Point dir, Size size):base(pos,dir,size)
        {

        }
        public override void Draw()
        {
            Game.buffer.Graphics.DrawRectangle(Pens.OrangeRed, pos.X, pos.Y, size.Width, size.Height);
        }

        public override void Regenerate()
        {
            pos.X = 0;           
        }

        public override void Update()
        {
            pos.X += 3;
        }


    }
}
