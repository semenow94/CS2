using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    class Bullet : BaseObject
    {
        public Bullet(Point pos)
        {
            Pos = pos;
            Size = new Size(4, 1);

        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawRectangle(Pens.OrangeRed, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {
            Pos.X +=5;
        }
        //public void OnStart()
        //{
        //    Pos.X = 0;
        //    Update();
        //}

    }
}
