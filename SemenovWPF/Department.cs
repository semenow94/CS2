using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SemenovWPF
{
    public class Department : INotifyPropertyChanged
    {
        string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public Department(ObservableCollection<Department> _departments,string name)
        {
            Add(_departments,name);
        }
        public Department(string name)
        {
            Name = name;
        }
        public static void Add(ObservableCollection<Department> _departments,string str)
        {
            bool dep = false;
            foreach(Department a in _departments)
            {
                if (a.Name.ToLower() == str.ToLower()) dep = true;
            }
            if (!dep) _departments.Add(new Department(str));
            else MessageBox.Show("Такой департамент существует, добавление не произошло");
        }
        public static void ReWrite(ObservableCollection<Department> _departments, int id, string str)
        {
            bool dep = false;
            foreach (Department a in _departments)
            {
                if (a.Name.ToLower() == str.ToLower()) dep = true;
            }
            if (!dep) _departments[id].Name=str;
            else MessageBox.Show("Такой департамент существует, изменение не произошло");
        }
        public override string ToString()
        {
            return Name;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
