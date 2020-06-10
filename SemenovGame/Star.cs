using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    class Star : BaseObject
    {
        public Star()
        {
            Pos = new Point(Game.Width, rand.Next(30, Game.Height - 3));
            Dir.X = rand.Next(5, 30);
            Size = new Size(3, 3);
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
            Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);
        }
        public override void Update()
        {
            Pos.X -=Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width - Size.Width;
        }
    }
}
