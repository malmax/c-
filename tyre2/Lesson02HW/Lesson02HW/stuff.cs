using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson02HW
{
    abstract class Stuff:IComparable
    {
        protected string lastName, firstName, type; 
               
        public abstract double getSalary();

        public int CompareTo(object obj)
        {
            return string.Compare(this.lastName,(obj as Stuff).lastName);
        }

        public Stuff(string lastName, string firstName)
        {
            this.lastName = lastName;
            this.firstName = firstName;
        }

        public override string ToString()
        {
            return "Сотрудник "+ this.lastName + " " + this.firstName + " работает по схеме: " + this.type + 
                ".\n Зарплата за предыдущий месяц: " + this.getSalary()+"\n\n";
        }
    }
}
