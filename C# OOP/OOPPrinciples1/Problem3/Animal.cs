using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3
{
    public abstract class Animal : ISound
    {
        private string name;
        private int age;
        public Gender Gender { get; private set; }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("name", "Name cannot be empty");
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
                if(value < 0)
                {
                    throw new ArgumentOutOfRangeException("age", "Age cannot be less than 0");
                }

                this.age = value;
            }
        }


        public Animal(string name, int age, Gender gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public Animal(string name ,int age) : this(name, age, Gender.Other)
        {
        }

        public override string ToString()
        {
            return String.Format("{0} -- {1} -- {2}", this.Name, this.Age, this.Gender);
        }

        abstract public void ProduceSound();    //left to be implemented by inheritors
    }
}
