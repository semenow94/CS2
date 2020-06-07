using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Построить три  класса(базовый и  2  потомка),  описывающих работников  с почасовой  оплатой(один из  потомков)  и фиксированной оплатой(второй потомок) :
//Описать в базовом классе абстрактный метод для расчета среднемесячной заработной платы.Для «повременщиков» формула для расчета такова: «среднемесячная заработная плата = 20.8 * 8 * почасовая ставка»; для работников  с фиксированной  оплатой: «среднемесячная заработная плата = фиксированная месячная оплата»;
//Создать на базе абстрактного класса массив сотрудников и заполнить его;
//* Реализовать интерфейсы для возможности сортировки массива, используя Array.Sort(); Для массива, подходит так же как и для Листа
//* Создать класс, содержащий массив сотрудников, и реализовать возможность вывода данных с использованием foreach.
//Немного изменил под лист сотрудников, думаю так правильнее, ведь количество сотрудников может меняться и так будет лучше чем менять размер массива.
namespace SemenovWorkers
{
    class Program
    {
        //Сортировка по фамилии
        public class NameComparer : IComparer<Worker>
        {
            public int Compare(Worker x, Worker y) => x.Name.CompareTo(y.Name);
        }
        //Сортировка по среднемесячному окладу
        public class PayComparer : IComparer<Worker>
        {
            public int Compare(Worker x, Worker y) => (int)(x.MonthPay() - y.MonthPay());
        }
        static void Main()
        {
            Random random = new Random();
            List<Worker> _workers = new List<Worker>(); ;
            for(int i=0; i<20; i++)
            {
                string name = "Name" + i;
                string surname = "Surame" + i;
                int r = random.Next(0, 2);
                double pay;
                if (r==0)
                {
                    pay = Math.Round(random.NextDouble() * 10000, 2);
                    _workers.Add(new FixPayWorker(name, surname+"F", pay));
                }
                else
                {
                    //При умножении на 60 у них должны получаться примерно равные зарплаты
                    pay = Math.Round(random.NextDouble() * 60, 2);
                    _workers.Add(new HourPayWorker(name, surname+"H", pay));
                }
            }
            WorkersArray arr = new WorkersArray(_workers);
            foreach (Worker a in arr.workers) Console.WriteLine(a);
            arr.workers.Sort(new NameComparer());
            Console.WriteLine();
            foreach (Worker a in arr.workers) Console.WriteLine(a);
            arr.workers.Sort(new PayComparer());
            Console.WriteLine();
            foreach (Worker a in arr.workers) Console.WriteLine(a);
            Console.ReadLine();
        }
    }
}
