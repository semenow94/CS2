using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    class HealBox : BaseObject
    {
        private static readonly Image img = Image.FromFile("healbox.png");
        Rectangle rectangle;
        public HealBox()
        {
            Init();
        }
        public override void Update()
        {
            Pos.X -= Dir.X;
            if (Pos.X < 0 & rand.Next(0, 100) > 90)
            {
                Init();
            } 
            rectangle = new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(img, rectangle);
        }
        void Init()
        {
            Size = new Size(25, 25);
            Pos = new Point(Game.Width, rand.Next(30, Game.Height - Size.Height));
            Dir.X = 10;
        }
    }
}
