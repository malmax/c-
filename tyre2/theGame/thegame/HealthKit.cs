using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thegame
{
    class HealthKit:BaseObject
    {
        static Image healImage = Image.FromFile("healthcare.png");
        public int energyRestore = 10;

        public HealthKit(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(healImage, new Rectangle(new Point(pos.X, pos.Y), new Size(size.Width, size.Height)));
        }

        public override void Update()
        {
            pos.X += dir.X;
            if (pos.X < 0)
            {
                pos.X = Game.rnd.Next(1, 3) * Game.Width;
                pos.Y = Game.rnd.Next(0, Game.Height);
            }

        }

        public override void Regenerate()
        {
            pos.X = Game.Width + Game.rnd.Next(1, 3) * Game.Width;
            pos.Y = Game.rnd.Next(Game.Height);
        }
    }
}
