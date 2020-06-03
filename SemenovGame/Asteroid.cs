using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    class Asteroid : BaseObject
    {
        Image img= Image.FromFile("asteroid.png");
        Rectangle rectangle;
        public Asteroid() : base()
        {
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(img, rectangle);
        }
        public override void Update()
        {
            Pos.X += Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
            int y = Pos.Y + (int)(Math.Sin(Pos.X/10) * 20);
            rectangle = new Rectangle(Pos.X, y, Size.Width, Size.Height);
        }
    }
}
