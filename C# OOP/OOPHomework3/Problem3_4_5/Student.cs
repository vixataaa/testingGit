using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3_4_5
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        private static Random rnd = new Random(DateTime.Now.Millisecond - DateTime.Now.Second);
        private const string letters = "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz";

        public Student(bool randomSet, string firstName = "fName", string lastName = "lName", int age = 42)
        {
            if (randomSet)
            {
                this.FirstName = letters.Substring(rnd.Next(0, 77 - 16), rnd.Next(5, 15));
                this.LastName = letters.Substring(rnd.Next(0, 77 - 16), rnd.Next(5, 15));
                this.Age = rnd.Next(14, 50);
            }//sets randomly for tests
            else
            {
                this.FirstName = firstName;
                this.LastName = lastName;
                this.Age = age;
            }//if randomSet is false
        }//constructor

        public bool FirstBeforeLast()
        {
            if(this.FirstName.CompareTo(this.LastName) < 0)
            {
                return true;
            }

            return false;
        }//checks if first name is before last alphabetically

        public override string ToString()
        {
            return String.Format($"First name: {this.FirstName} \nLast name: {this.LastName} \nAge: {this.Age}");
        }
    }
}
