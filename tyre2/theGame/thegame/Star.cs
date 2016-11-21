using System;
using System.Drawing;


namespace thegame
{
     class Star : BaseObject
        {
            Color color;
            public Star(Point pos, Point dir, Size size):base(pos,dir,size)
            {
                this.color = Color.FromArgb(Game.rnd.Next(0, 255), Game.rnd.Next(0, 255),Game.rnd.Next(0, 255));
            }

            public override void Draw()
            {
               // Game.buffer.Graphics.DrawEllipse(Pens.Beige, pos.X, pos.Y, size.Width, size.Height);

                Game.buffer.Graphics.DrawLine(new Pen(color), pos.X, pos.Y, pos.X + size.Width, pos.Y + size.Height);
                Game.buffer.Graphics.DrawLine(new Pen(color), pos.X + size.Width, pos.Y, pos.X, pos.Y + size.Height);
            }

            public override void Update()
            {
                pos.X += dir.X;
                if (pos.X < 0)
                {
                    pos.X = Game.Width + size.Width;
                    pos.Y = Game.rnd.Next(0, Game.Height);
                    this.color = Color.FromArgb(Game.rnd.Next(0, 255), Game.rnd.Next(0, 255), Game.rnd.Next(0, 255));
                }
            }
        }
    }

