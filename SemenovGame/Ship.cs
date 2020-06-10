using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    class Ship : BaseObject
    {
        private int _energy = 100;
        private int _score = 0;
        public int Energy => _energy;
        public int Score => _score;

        public void EnergyLow(int n)
        {
            _energy -= n;
            print($"Ship take {n} damage. Current energy is {_energy}");
        }
        public void Heal(int n)
        {
            _energy += n;
            if (_energy > 100)
            {
                _energy = 100;
            }
            print($"Ship was healed. Current energy is {_energy}");
        }
        public void ScoreUp(int n)
        {
            _score += n;
        }
        public Ship(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(Brushes.Wheat, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {
        }
        public void Up()
        {
            if (Pos.Y > 30) Pos.Y -=Dir.Y;
        }
        public void Down()
        {
            if (Pos.Y < Game.Height) Pos.Y +=Dir.Y;
        }
        public void Die()
        {
            print("Game over");
            MessageDie?.Invoke();
        }
        public static event Message MessageDie;
    }
}
