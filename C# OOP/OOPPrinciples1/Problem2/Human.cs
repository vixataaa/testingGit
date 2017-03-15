using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    public abstract class Human
    {
        private string firstName;
        private string lastName;
        
        public Human(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }
        
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(value, "First name cannot be empty");
                }

                this.firstName = value;
            }
        }       
        
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(value, "Last name cannot be empty");
                }

                this.lastName = value;
            }
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", this.FirstName, this.LastName);
        }
    }
}
