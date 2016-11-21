using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lesson3
{        

    

    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = null;
            sr = new StreamReader("D:\\temp\\1.txt");          
            try
            {                
                int a = Convert.ToInt32("111111111111111111111111111111111111111111");
            }
            catch(OverflowException exc)
            {
                Console.WriteLine(exc.Message);
                Console.WriteLine("Overflow");
            }
            catch
            {
                Console.WriteLine("Error!");
                int a = Convert.ToInt32("111");
            }
            finally
            {
                if (sr != null) sr.Close();
            }
            Console.ReadKey();
        }
    }
}
