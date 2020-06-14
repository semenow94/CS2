using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Дана коллекция List<T>.Требуется подсчитать, сколько раз каждый элемент встречается в данной коллекции:
//для целых чисел;
//* для обобщенной коллекции;
//** используя Linq.
//Семенов
namespace SemenovLn4T2
{
    class Program
    {
        static void Main()
        {
            Random rand = new Random();
            List<int> intList = new List<int>();
            Console.WriteLine("Int List");
            for(int i=0; i<30; i++)
            {
                intList.Add(rand.Next(0, 6));
                Console.Write(intList[i]+" ");
            }
            Console.WriteLine();
            EntriesCount(intList);
            Console.WriteLine();
            string[] strs={"abc","asd","qwe","lol", "sad" };
            List<string> strList = new List<string>();
            for (int i = 0; i < 30; i++)
            {
                string str=strs[rand.Next(0, strs.Length)];
                strList.Add(str);
                Console.Write(strList[i] + " ");
            }
            Console.WriteLine();
            EntriesCount(strList);
            Console.ReadLine();
        }
        static void EntriesCount<T>(List<T> arr)
        {
            Dictionary<T, int> eCount = new Dictionary<T, int>();
            foreach (var elem in arr)
            {
                if (eCount.ContainsKey(elem))
                    eCount[elem]++;
                else
                    eCount.Add(elem, 1);                
            }
            foreach (var elem in eCount)
                Console.WriteLine($"{elem.Key} have {elem.Value} entries");
        }
    }
}
