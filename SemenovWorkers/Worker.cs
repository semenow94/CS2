using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemenovWorkers
{
    abstract class Worker
    {
        public string Name { get; }
        public string Surname { get; }
        public double Pay { get; }

        public Worker(string name, string surname, double pay)
        {
            Name = name;
            Surname = surname;
            if (pay <= 0) throw new ArgumentOutOfRangeException("Pay must be biggest then 0");
            Pay = pay;
        }
        public override string ToString()
        {
            string str;
            str = Surname + " " + Name + " " + MonthPay();
            return str;
        }
        public abstract double MonthPay();
    }
}
