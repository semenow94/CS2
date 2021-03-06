﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace WindowsFormsApp1
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        static private int width;
        static private int height;
        public static BaseObject[] _objs;
        private static readonly List<Bullet> _bullets = new List<Bullet>();
        private static HealBox heal;
        static int asteroidCount=10;
        private static readonly List<Asteroid> _asteroids=new List<Asteroid>();
        private static readonly Ship _ship = new Ship(new Point(20, 400), new Point(5, 5), new Size(10, 10));
        private static readonly Timer timer = new Timer { Interval = 100 };
        public static Random Rnd = new Random();
        static readonly string filepath = "log.txt";
        public static int Width
        {
            get
            {
                return width;
            }
            set
            {
                if (value > 1000 || value < 0)
                    throw new ArgumentOutOfRangeException("Bad value");
                else width = value;
            }
        }
        public static int Height
        {
            get
            {
                return height;
            }
            set
            {
                if (value > 1000 || value < 0)
                    throw new ArgumentOutOfRangeException("Bad value");
                else height = value;
            }
        }
        static Game()
        {
        }
        static void AsteroidInit()
        {
            for (var i = 0; i < asteroidCount; i++)
            {
                _asteroids.Add(new Asteroid());
                _asteroids[i].print = MessagePrint;
            }
        }
        public static void Init(Form form)
        {
            File.Delete(filepath);
            using (File.Create(filepath));
                // Графическое устройство для вывода графики            
                Graphics g;
            // Предоставляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            // Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            timer.Start();
            timer.Tick += Timer_Tick;
            form.KeyDown += Form_KeyDown;
            Ship.MessageDie += Finish;
        }
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey) _bullets.Add(new Bullet(new Point(_ship.Rect.X + 10, _ship.Rect.Y + 4)));
            if (e.KeyCode == Keys.Up) _ship.Up();
            if (e.KeyCode == Keys.Down) _ship.Down();
        }
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
                obj.Draw();
            foreach (Asteroid a in _asteroids)
            {
                a?.Draw();
            }
            foreach (Bullet b in _bullets) b.Draw();
            heal?.Draw();
            _ship?.Draw();
            if (_ship != null)
            {
                Buffer.Graphics.DrawString("Energy:" + _ship.Energy, SystemFonts.DefaultFont, Brushes.White, 0, 0);
                Buffer.Graphics.DrawString("Score:" + _ship.Score, SystemFonts.DefaultFont, Brushes.White, 0, 15);
            }
            Buffer.Render();

        }
        public static void Update()
        {
            var rnd = new Random();
            foreach (BaseObject obj in _objs) obj.Update();
            foreach (Bullet b in _bullets) b.Update();
            if (heal == null & rnd.Next(0, 100) > 90) heal = new HealBox();
            heal?.Update();
            for(int i=0; i<_bullets.Count; i++)
            {
                if(_bullets[i].Pos.X>Game.Width)
                {
                    _bullets.RemoveAt(i);
                    i--;
                }
            }
            for (int i = 0; i < _asteroids.Count; i++)
            {
                _asteroids[i].Update();
                for (int j = 0; j < _bullets.Count; j++)
                {
                    if (_bullets[j].Collision(_asteroids[i]))
                    {
                        System.Media.SystemSounds.Hand.Play();
                        _asteroids[i].print("Asteroid destroy");
                        _asteroids.RemoveAt(i);
                        i--;
                        _bullets.RemoveAt(j);
                        j--;
                        _ship.ScoreUp(5);
                        continue;
                    }
                }
            }
            for (int i = 0; i < _asteroids.Count; i++)
            {
                if (_ship.Collision(_asteroids[i]))
                {
                    _ship.EnergyLow(Rnd.Next(1, 10));
                    _asteroids.RemoveAt(i);
                    i--;
                    System.Media.SystemSounds.Asterisk.Play();
                    if (_ship.Energy <= 0) _ship.Die();
                }
            }
            if (_asteroids.Count==0)
            {
                asteroidCount++;
                AsteroidInit();
            }
            if(heal!=null)
            {
                if (_ship.Collision(heal))
                {
                    heal = null;
                    _ship.Heal(10);
                }
            }
        }
        public static void Load()
        {
            _objs = new BaseObject[30];
            heal = new HealBox();
            var rnd = new Random();
            AsteroidInit();
            for (var i = 0; i < _objs.Length; i++)
            {
                int r = rnd.Next(5, 50);
                _objs[i] = new Star();
            }
            _ship.print = MessagePrint;
        }
        public static void Finish()
        {
            timer.Stop();
            Buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 200, 100);
            Buffer.Render();
        }
        static void MessagePrint(string str)
        {
            Console.WriteLine(str);
            if (File.Exists(filepath))
            {
                using (StreamWriter writer = File.AppendText(filepath))
                    writer.WriteLine(str);
            }
        }
    }
}