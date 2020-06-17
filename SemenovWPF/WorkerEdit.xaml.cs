﻿using System;
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
using System.Windows.Shapes;

namespace SemenovWPF
{
    /// <summary>
    /// Логика взаимодействия для WorkerEdit.xaml
    /// </summary>
    public partial class WorkerEdit : Window
    {
        public ObservableCollection<string> Departments { get; set; }
        public ObservableCollection<Employee> workers;
        public WorkerEdit(ObservableCollection<Employee> _workers)
        {
            workers = _workers;
            Departments = Department.departments;
            DataContext = this;
            InitializeComponent();
            Name.Text = "";
            Surname.Text = "";
            Age.Text = "";
            Workerid.Text = "-1";
            AddRew.Content = "Добавить";
        }
        public WorkerEdit(ObservableCollection<Employee> _workers,string name, string surname, int age, int depid, int id)
        {
            workers = _workers;
            Departments = Department.departments;
            DataContext = this;
            InitializeComponent();
            Name.Text = name;
            Surname.Text = surname;
            Age.Text = age.ToString();
            DepartmentName.SelectedIndex=depid;
            Workerid.Text = id.ToString();
            AddRew.Content = "Изменить";
        }

        private void Form_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddRew_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(Workerid.Text);
            if (id>=0)
            {
                workers[id].Name = Name.Text;
                workers[id].Surname = Surname.Text;
                workers[id].Age = Convert.ToInt32(Age.Text);
                workers[id].DepartmentId = DepartmentName.SelectedIndex;
            }
            else
            {
                workers.Add(new Employee(Name.Text, Surname.Text, DepartmentName.SelectedIndex, Convert.ToInt32(Age.Text)));
            }
            this.Close();
        }
    }
}
