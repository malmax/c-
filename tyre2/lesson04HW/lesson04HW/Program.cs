using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Малахов Максим
//Дана коллекция List<T>, требуется подсчитать, сколько раз каждый элемент встречается в
//данной коллекции.
//а) для целых чисел;
//б) * для обобщенной коллекции;
//в)** используя Linq


using ExtensionMethods;
// Пример метода расширений (слово this перед параметром)
// https://msdn.microsoft.com/ru-ru/library/bb383977.aspx
namespace ExtensionMethods
{
    public static class MyExtensions
    {
        //а) для целых чисел;
        public static Dictionary<int,int> countRepeatInList(this List<int> list)
        {
            Dictionary<int, int> array = new Dictionary<int, int>();
            foreach(int Num in list)
            {
                if (array.ContainsKey(Num))
                    array[Num]++;
                else
                    array.Add(Num, 1);
            }
            return array;
        }
        //б) * для обобщенной коллекции;
        public static Dictionary<T,int> countRepeatInList2<T>(this List<T> list)
        {
            Dictionary<T, int> array = new Dictionary<T, int>();
            foreach (var Num in list)
            {
                if (array.ContainsKey(Num))
                    array[Num]++;
                else
                    array.Add(Num, 1);
            }
            return array;
        }
        //в)** используя Linq
        public static Dictionary<T, int> countRepeatInListLinq<T>(this List<T> list)
        {
            
            var listResult = from n in list
                             group n by n into gr
                             select new KeyValuePair<T,int>( gr.First(), gr.Count() );
            
            Dictionary<T, int> array = listResult.ToDictionary(x=>x.Key,x=>x.Value);

            return array;
        }
    }
}

namespace lesson04HW
{
    class Program
    {
        static void Main(string[] args)
        {
            //Дана коллекция List<T>, требуется подсчитать, сколько раз каждый элемент встречается в
            //данной коллекции.
            //а) для целых чисел;
            Task1();
            Task2();
            TaskLinq();
        }

        static void Task1()
        {
            List<int> list = new List<int>() { 1, 10, 13, 7, 10, 5, 1 };
            Dictionary<int, int> list2 = list.countRepeatInList();
            foreach (KeyValuePair<int, int> pair in list2)
            {
                Console.WriteLine("{0}", pair);
            }

            Console.ReadKey();
        }

        static void Task2()
        {
            List<string> list = new List<string>() { "бла", "хо", "а", "бла", "ням", "да", "а" };
            Dictionary<string, int> list2 = list.countRepeatInList2();
            foreach (KeyValuePair<string, int> pair in list2)
            {
                Console.WriteLine("{0}", pair);
            }

            Console.ReadKey();
        }
        static void TaskLinq()
        {
            List<string> list = new List<string>() { "бла", "хо", "а", "бла", "ням", "да", "а" };
            Dictionary<string, int> list2 = list.countRepeatInListLinq();
            foreach (KeyValuePair<string, int> pair in list2)
            {
                Console.WriteLine("{0}", pair);
            }

            Console.ReadKey();
        }
    }
}
