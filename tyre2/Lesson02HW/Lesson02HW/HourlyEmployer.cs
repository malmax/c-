using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson02HW
{
    class HourlyEmployer : Stuff
    {
        protected int hourlySalary = 100;
        public double HoursWorked { get; set; }

        public HourlyEmployer(string lastName, string firstName):base(lastName, firstName)
        {
            this.type = "почасовая оплата";
            this.HoursWorked = 20.8 * 8;
        }

        public override double getSalary()
        {
            return this.HoursWorked * this.hourlySalary;
        }
    }
}
