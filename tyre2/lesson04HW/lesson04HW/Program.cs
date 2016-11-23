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

        public static Dictionary<T,int> countRepeatInList2(this List<T> list)
        {

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
    }
}
