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
        public Asteroid()
        {
            Init();
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(img, rectangle);
        }
        public override void Update()
        {
            Pos.X -= Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
            rectangle = new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public void Reload()
        {
            Init();
            print("Asteroid destroy");
        }
        void Init()
        {
            Size = new Size(rand.Next(20, 50), rand.Next(20, 50));
            Dir.X = rand.Next(5, 20);
            Pos = new Point(Game.Width, rand.Next(30, Game.Height - Size.Height));
            Power = 1;
        }
        
        //public void OnStart()
        //{
        //    Pos.X = Game.Width;
        //    Update();
        //}
    }
}
