using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    public class Worker : Human
    {
        private double weekSalary;
        private double workHoursPerDay;

        public double WeekSalary
        {
            get
            {
                return this.weekSalary;
            }
            private set
            {
                if(value < 0)
                {
                    throw new ArgumentOutOfRangeException("weekSalary", "Salary cant be less than 0");
                }

                this.weekSalary = value;
            }            
        }

        public double WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }
            private set
            {
                if(value < 1 && value > 24)
                {
                    throw new ArgumentOutOfRangeException("workHoursPerDay", "Work hours per day cant be less than 1 or greater than 24");
                }

                this.workHoursPerDay = value;
            }
        }

        public Worker(string firstName, string lastName, double weekSalary, double workHoursPerDay) : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public double MoneyPerHour()
        {
            return this.weekSalary / (this.workHoursPerDay * 5);    //assuming he`s working 5 days a week
        }
    }
}
