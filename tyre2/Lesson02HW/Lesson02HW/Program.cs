using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 
 * Малахов Максим
 * 
 * Построить три класса (базовый и 2 потомка), описывающих некоторых работников с
 * почасовой оплатой (один из потомков) и фиксированной оплатой (второй потомок).
 * а) Описать в базовом классе абстрактный метод для расчёта среднемесячной заработной
 * платы. Для «повременщиков» формула для расчета такова: «среднемесячная заработная плата
 * = 20.8 * 8 * почасовую ставку», для работников с фиксированной оплатой «среднемесячная
 * заработная плата = фиксированной месячной оплате».
 * б) Создать на базе абстрактного класса массив сотрудников и заполнить его.
 * в) **Реализовать интерфейсы для возможности сортировки массива используя Array.Sort().
 * г) ***Реализовать возможность вывода данных с использованием foreach.
 */


namespace Lesson02HW
{
    class Program
    {
        static Stuff[] employers = new Stuff[10];
        static Random rnd = new Random();
        static char[] strArr = "qwertyuiopasdfghjklzxcvbnm".ToCharArray();

        static void Main(string[] args)
        {
            //Create employers
            for(int i=0;i<employers.Length;i++)
            {
                string[] name = getName();

                switch(rnd.Next(0,2))
                {
                    case 0:
                        employers[i] = new Employer(name[0],name[1]);
                        break;

                    case 1:
                        employers[i] = new HourlyEmployer(name[0], name[1]);
                        break;
                }
            }

            //Выводим всех сотрудников
            foreach(Stuff obj in employers)
            {
                Console.WriteLine(obj);
            }
            Console.ReadKey();

        }

        private static string[] getName()
        {
            //Create employers
            string lastName;
            string firstName;

            lastName = "";
            for (int i = 0; i < rnd.Next(3, 10); i++)
                lastName += strArr[rnd.Next(0, strArr.Length)];
            lastName = lastName.First().ToString().ToUpper() + String.Join("", lastName.Skip(1));

            firstName = "";
            for (int i = 0; i < rnd.Next(3, 7); i++)
                firstName += strArr[rnd.Next(0, strArr.Length)];
            firstName = firstName.First().ToString().ToUpper() + String.Join("", firstName.Skip(1));

            return new string[] { lastName, firstName };
        }
    }
}
