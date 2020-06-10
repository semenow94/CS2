using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp1
{
    interface ICollision
    {
        bool Collision(ICollision obj);
        Rectangle Rect { get; }
    }
    public delegate void Message();
    abstract class BaseObject : ICollision
    {
        public static Random rand = new Random();
        public delegate void Print(string str);
        public Print print;
        public Point Pos;
        protected Point Dir;
        protected Size Size;
        public BaseObject()
        {
            //if (pos.X < 0 || pos.X > Game.Width || pos.Y < 0 || pos.Y > Game.Height)
            //{
            //    throw new GameObjectException("Bad position");
            //}
            
        }
        public abstract void Draw();
        public abstract void Update();
        public bool Collision(ICollision o) => o.Rect.IntersectsWith(this.Rect);
        public Rectangle Rect => new Rectangle(Pos, Size);

    }
}
