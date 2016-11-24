using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//малахов Максим
//
namespace Lesson04HWTask4
{
    class Program
    {
        static void Main(string[] args)
        {
            Example();
            Console.ReadKey();
            Solution1();
            Console.ReadKey();
            Solution2();
            Console.ReadKey();
        }
        // *Дан фрагмент программы:
        static void Example()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>()
                 {
                 {"four",4 },
                 {"two",2 },
                 { "one",1 },
                 {"three",3 },
                 };
            var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair) { return pair.Value; });
            foreach (var pair in d)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
        }
        //а) Свернуть обращение к OrderBy с использованием лямбда-выражения
        static void Solution1()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>()
                 {
                 {"four",4 },
                 {"two",2 },
                 { "one",1 },
                 {"three",3 },
                 };
            var d = dict.OrderBy(x => x.Value);
            foreach (var pair in d)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
        }
        //б) *Развернуть обращение к OrderBy с использованием делегата Predicate<T>
        static void Solution2()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>()
                 {
                 {"four",4 },
                 {"two",2 },
                 { "one",1 },
                 {"three",3 },
                 };
            //var d = dict.OrderBy(x => x.Value);

            Predicate<KeyValuePair<string, int>> predicate = new Predicate<KeyValuePair<string, int>>(_orderhelper);
            var d = dict.OrderBy(predicate);
            foreach (var pair in d)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
        }        
        static int _orderhelper(KeyValuePair<string, int> value1)
        {
            //return value2.Value > value1.Value;
            return value1.Value;
        }
    }
}
