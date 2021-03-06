﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thegame
{
    class Ship : BaseObject
    {
        int energy = 10;
        public bool up = false, down = false, left = false, right = false;
        Image starShipImage = Image.FromFile("shship.png");
        public bool enable = true;

        public static event Message MessageDie;

        public int Energy
        {
            get { return energy; }
        }
        public void EnergyLow(int n)
        {
            { energy -= n; }
        }
        public void EnergyUp(int n)
        {
            { energy += n; }
        }
        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            if(enable)
                Game.buffer.Graphics.DrawImage(starShipImage, new Rectangle(new Point(pos.X, pos.Y), new Size(size.Width, size.Height)));
            else
                Game.buffer.Graphics.DrawString("Game Over", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 200, 150);

        }
        public override void Update()
        {
            if(up)
            {
                if(pos.Y > 0) pos.Y = pos.Y - dir.Y;
            }
            if(down)
            {
                if (pos.Y < Game.Height) pos.Y = pos.Y + dir.Y;
            }
            if(left)
            {
                if (pos.X > 0) pos.X = pos.X - dir.X;
            }
            if (right)
            {
                if (pos.X < Game.Width) pos.X = pos.X + dir.X;
            }
        }
        
        public void Die()
        {
            enable = false;
            if (MessageDie != null) MessageDie();
        }
        public bool Collision(ICollision obj)
        {
            if (obj.Rect.IntersectsWith(this.Rect) && enable) return true; else return false;
        }

    }
}
