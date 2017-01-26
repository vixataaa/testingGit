using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    public class Student : Person
    {
        private int uniqueID;
        private ClassOfStudents classJoined;

        public int UniqueID
        {
            get
            {
                return this.uniqueID;
            }
            set
            {
                //the ID should be assigned by ClassOfStudents when a student gets added
                if (this.uniqueID != 0 && value != 0)
                {
                    throw new InvalidOperationException("The student already has an Unique ID.");
                }

                this.uniqueID = value;
            }
        }

        public ClassOfStudents ClassJoined
        {
            get
            {
                return this.classJoined;
            }
            set
            {
                //wont allow changing student class after being once added
                if(this.classJoined != null)
                {
                    throw new InvalidOperationException("The student already has a class.");
                }

                this.classJoined = value;
            }
        }      

        public Student(string name, params string[] comments) : base(name, comments)
        {
            this.UniqueID = 0;
            this.ClassJoined = null;
        }

        public override string ToString()
        {
            return String.Format("  -Student - {0} - {1}",this.UniqueID, base.ToString());
        }
    }
}
