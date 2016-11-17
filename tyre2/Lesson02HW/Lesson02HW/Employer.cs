using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson02HW
{
    class Employer : Stuff
    {
        protected double monthSalary = 20000;        

        public Employer(string lastName, string firstName):base(lastName, firstName)
        {
            this.type = "помесячная оплата";
        }

        public override double getSalary()
        {
            return this.monthSalary;
        }
    }
}
