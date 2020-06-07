using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemenovWorkers
{
    class FixPayWorker : Worker
    {
        public FixPayWorker(string name, string surname, double pay) : base(name, surname, pay)
        {
        }
        public override double MonthPay()
        {
            return Pay;
        }
    }
}
