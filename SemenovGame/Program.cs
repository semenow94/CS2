using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Form form = new Form
            {
                Width = 900,
                Height = 900
            };
            Game.Init(form);
            Game.Load();
            form.Show();
            Game.Draw();
            Application.Run(form);
        }
    }
}
