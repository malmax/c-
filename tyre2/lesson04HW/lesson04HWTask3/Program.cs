using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Малахов Максим 
// *С клавиатуры вводится скобочное выражение. Требуется проверить правильность расстановки
// скобок. (Использовать обобщенную коллекцию Stack<char>)
namespace lesson04HWTask3
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> letter = new Stack<char>();
            
            string str = "<div class='main'><a href='#'>()</a></div>";
            foreach(char c in str)
            {
                if(Array.Exists(new char[] { '[', ']', '<', '>', '(', ')' }, el => el == c))
                {
                    letter.Push(c);
                }
            }

            var stkCount = from l in letter
                           group l by l into gr
                           select new KeyValuePair<char, int>(gr.First(), gr.Count());

            foreach (KeyValuePair<char, int> pair in stkCount)
            {
                Console.WriteLine("{0}", pair);
            }

            Console.ReadKey();
        }
    }
}
