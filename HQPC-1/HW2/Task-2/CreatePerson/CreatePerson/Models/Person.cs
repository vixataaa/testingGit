using System;
using CreatePerson.Contracts;
using CreatePerson.Enumerations;

namespace CreatePerson.Models
{
    public class Person : IPerson
    {
        private string name;
        private int age;

        public Person(string name, int age, Gender gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age cannot be less than zero");
                }

                this.age = value;
            }
        }

        public Gender Gender { get; private set; }
    }
}
