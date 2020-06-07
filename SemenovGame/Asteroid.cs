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
        public int Power { get; set; }
        private static readonly Image img= Image.FromFile("asteroid.png");
        Rectangle rectangle;
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Power = 1;
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(img, rectangle);
        }
        public override void Update()
        {
            Pos.X += Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
            rectangle = new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public void OnStart()
        {
            Pos.X = Game.Width;
            Update();
        }
    }
}
