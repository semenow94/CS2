using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

//Создать WPF-приложение для ведения списка сотрудников компании.
//1. Создать сущности Employee и Department и заполните списки сущностей начальными данными.
//2. Для списка сотрудников и списка департаментов предусмотреть визуализацию (отображение). Это можно сделать, например, с использованием ComboBox или ListView.
//3. Предусмотреть возможность редактирования сотрудников и департаментов. Должна быть возможность изменить департамент у сотрудника.Список департаментов для выбора, можно выводить в ComboBox, это все можно выводить на дополнительной форме.
//4. Предусмотреть возможность создания новых сотрудников и департаментов.Реализовать данную возможность либо на форме редактирования, либо сделать новую форму.
//Семенов Дмитрий
namespace SemenovWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Employee> Workers { get; set; }
        public ObservableCollection<Department> Departments { get; set; }
        readonly List<string> _departments= new List<string>
            {
                "ИТ", "Бухгалтерия", "Администрация"
            };
        public MainWindow()
        {
            InitializeComponent();
            Init();
            
        }
        void Init()
        {
            Departments = new ObservableCollection<Department>();
            Workers = new ObservableCollection<Employee>();
            Random rand = new Random();
            foreach (string a in _departments)
            {
                Departments.Add(new Department(a));
            }
            for (int i = 0; i < 10; i++)
            {
                Workers.Add(new Employee("Name" + i, "Surname" + i, Departments[rand.Next(0, Departments.Count)], rand.Next(18, 66)));
            }
            DataContext = this;
        }
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            tab.Height = this.Height - 31;
            tab.Width = this.Width - 8;
        }

        private void Dep_Add(object sender, RoutedEventArgs e)
        {
            DepartmentEdit dep = new DepartmentEdit(Departments);
            dep.ShowDialog();
        }

        private void Worker_Add(object sender, RoutedEventArgs e)
        {
            WorkerEdit work = new WorkerEdit(Workers,Departments);
            work.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int i=listWorkers.SelectedIndex;
            if(i >= 0 && MessageBox.Show("Are you sure?", "Warning", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                Workers.RemoveAt(i);
            }
        }
        private void Worker_Edit(object sender, RoutedEventArgs e)
        {
            int i = listWorkers.SelectedIndex;
            if (i>=0)
            {
                WorkerEdit work = new WorkerEdit(Workers,Departments, i);
                work.ShowDialog();
                listWorkers.ItemsSource = Workers;
            }
        }

        private void Dep_Edit_Click(object sender, RoutedEventArgs e)
        {
            int i = listDeps.SelectedIndex;
            if(i>=0)
            {
                DepartmentEdit dep = new DepartmentEdit(Departments,i);
                dep.ShowDialog();
                foreach (Employee a in Workers) a.OnPropertyChanged("Department"); //Вполне рабочий костыль =D
            }
        }
    }
}
