using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SemenovWPF
{
    static class Department
    {
        public static ObservableCollection<string> departments = new ObservableCollection<string>();
        //public string Name{get; set;}
        //public Department(string name)
        //{
        //    Add(name);
        //    Name = name;
        //}
        public static void Add(string str)
        {
            if (!departments.Contains(str)) departments.Add(str);
            else MessageBox.Show("Такой департамент существует, добавление не произошло");
        }
        public static void ReWrite(int id, string str)
        {
            if (!departments.Contains(str)) departments[id] = str;
            else MessageBox.Show("Такой департамент существует, изменение не произошло");
        }
        public static int GetDep(string str)
        {
            int i = departments.IndexOf(str);
            return i;
        }
    }
}
