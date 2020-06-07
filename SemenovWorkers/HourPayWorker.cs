using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemenovWorkers
{
    class HourPayWorker : Worker
    {
        public HourPayWorker(string name, string surname, double pay) : base(name, surname, pay)
        {
        }
        public override double MonthPay()
        {
            return Math.Round(20.8 * 8 * Pay,2);
        }
    }
}
