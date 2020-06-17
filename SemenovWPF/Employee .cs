using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SemenovWPF
{
    public class Employee : INotifyPropertyChanged
    {
        string name;
        string surname;
        int departmentId;
        int age;
        string departmentName;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                OnPropertyChanged("Surname");
            }
        }
        public string DepartmentName
        {
            get
            {
                return departmentName;
            }
            set
            {
                departmentName= value;
                OnPropertyChanged("DepartmentName");
            }
        }
        public int DepartmentId
        {
            get { return departmentId; }
            set
            {
                departmentId = value;
                DepartmentName = Department.departments[Convert.ToInt32(value)];
                OnPropertyChanged("DepartmentId");
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                OnPropertyChanged("Age");
            }
        }
        public Employee(string name, string surname, int department, int age)
        {
            Name = name;
            Surname = surname;
            DepartmentId = department;
            Age = age;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
