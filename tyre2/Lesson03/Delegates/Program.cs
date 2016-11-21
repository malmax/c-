using System;
// Пример использования делегата
// Передача делегата через список параметров
// C# Программирование на языке высокого уровня Т.А. Павловская  Питер 2009 г.
namespace DelegatesAndEvents_010
{
    public delegate double Fun(double x);

    class Program
    {
        public static void Table(Fun F, double x, double b)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(x));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }

        public static double Simple(double x)
        {
            return x * x;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Таблица функции Sin:");
            Table(new Fun(Math.Sqrt), -2, 2);
            Console.WriteLine("Таблица функции Simple:");
            Table(new Fun(Simple), 0, 3);
        }
    }
}