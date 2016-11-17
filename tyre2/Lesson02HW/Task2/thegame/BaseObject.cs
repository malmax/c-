using System;
using System.Drawing;

namespace thegame
{
    abstract class BaseObject: ICollision
    {
        protected Point pos;
        protected Point dir;
        protected Size size;

        public BaseObject(Point pos,Point dir, Size size)
        {

            if(pos.X < 0 || pos.Y < 0 || pos.X > 2000 || pos.Y > 2000)
                throw new GameObjectException("Неправильная стартовая позиция объекта");
            else
                this.pos = pos;

            if (Math.Abs(dir.X) > 20 || Math.Abs(dir.Y) > 20)
                throw new GameObjectException("Внимание! Превышение допустимой скорости");
            else
                this.dir = dir;

            if (size.Width > 200 || size.Height > 200 || size.Height < 0 || size.Width < 0)
                throw new GameObjectException("Размеры объекта либо меньше нуля, либо превышают 200 на 200");
            else
                this.size = size;

        }
        public BaseObject()
        { }

        public abstract void Draw();

        public abstract void Update();
        /*{
            pos.X = pos.X +2*dir.X;
            pos.Y = pos.Y + 2*dir.Y;
            if (pos.X < 0) dir.X = -dir.X;
            if (pos.X > Game.Width) dir.X = -dir.X;
            if (pos.X < 0) dir.Y= -dir.Y;
            if (pos.X > Game.Height) dir.Y = -dir.Y;
        }*/

        public Rectangle Rect
        {
            get
            {
                return new Rectangle(pos, size);
            }
        }

        public bool Collision(ICollision obj)
        {
            if (obj.Rect.IntersectsWith(this.Rect)) return true; else return false;
        }

        public virtual void Regenerate()
        {

        }
    }
}
