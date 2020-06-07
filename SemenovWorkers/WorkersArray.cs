using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SemenovWorkers
{
    class WorkersArray : IEnumerable
    {
        public List<Worker> workers;
        public WorkersArray(List<Worker> worker)
        {
            workers = worker;
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < workers.Count; i++)
                yield return workers[i];
        }
        
    }
}
