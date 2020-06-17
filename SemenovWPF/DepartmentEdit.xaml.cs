using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SemenovWPF
{
    /// <summary>
    /// Логика взаимодействия для DepartmentEdit.xaml
    /// </summary>
    public partial class DepartmentEdit : Window
    {
        public DepartmentEdit()
        {
            InitializeComponent();
            DepId.Text = "-1";
            DepEdit.Content = "Добавить";
            DepName.Text = "";
        }
        public DepartmentEdit(int id)
        {
            InitializeComponent();
            DepId.Text = id.ToString();
            DepEdit.Content = "Изменить";
            DepName.Text = Department.departments[id];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DepEdit_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(DepId.Text);
            if(id>=0)
            {
                Department.departments[id] = DepName.Text;
            }
            else
            {
                Department.Add(DepName.Text);
            }
            this.Close();
        }
    }
}
