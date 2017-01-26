using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    public class Student : Human
    {
        private double grade;

        public Student(string firstName, string lastName, double grade) : base(firstName, lastName)
        {
            this.grade = grade;
        }

        public double Grade
        {
            get
            {
                return this.grade;
            }
            private set
            {
                if (value < 2.00 && value > 6.00)
                {
                    throw new ArgumentOutOfRangeException("grade", "The grade cant be greater than 6 or less than 2");
                }
            }
        }
    }
}
