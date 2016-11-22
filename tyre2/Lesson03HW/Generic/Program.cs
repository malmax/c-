using System;
using System.Collections.Generic;


namespace Generic
{
    class Program
    {
        static void Swap<T>(ref T a,ref T b)
        {
            T t;
            t = a;
            a = b;
            b = t;
        }

        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("Left", "Влево");
            dict.Add("Up", "Вверх");
            if (dict.ContainsKey("login"))
                if (dict["login"] == "password") ;
        }
    }
}
