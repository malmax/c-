using System;
namespace GenericDelegate
{
    // Этот обобщённый делегат может вызывать любой метод, который возвращает void и принимает 
    //  единственный параметр типа
    public delegate void MyGenericDelegate<T>(T arg);

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Generic Delegates *****\n");
            // Зарегистрировать цели.
            MyGenericDelegate<string> strTarget = new MyGenericDelegate<string>(StringTarget);
            strTarget("Some string data");
            MyGenericDelegate<int> intTarget = new MyGenericDelegate<int>(IntTarget);
            intTarget(9);
            MyGenericDelegate<double> dblTaget = new MyGenericDelegate<double>(DoubleTarget);
            dblTaget(10.4);
            Console.ReadLine();
        }

        static void StringTarget(string arg)
        {
            Console.WriteLine("arg in uppercase is: {0}", arg.ToUpper());
        }

        static void IntTarget(int arg)
        {
            Console.WriteLine("++arg is: {0}", ++arg);
        }

        static void DoubleTarget(double arg)
        {

        }

    }
}
