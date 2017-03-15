using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem9_16_18
{
    public class Student
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string FacultyNumber { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public List<double> Marks { get; private set; }
        public Group Group { get; private set; }

        public Student(string fName, string lName, string fNumb, string phoneNumb, string email, List<double> marks, Group group)
        {
            this.FirstName = fName;
            this.LastName = lName;
            this.FacultyNumber = fNumb;
            this.PhoneNumber = phoneNumb;
            this.Email = email;
            this.Marks = marks;
            this.Group = group;
        }//constructor

        public override string ToString()
        {
            return String.Format("Names: {0} {1} \nFN: {2} \nPhone: {3} \nEmail: {4} \nMarks: {5} \n{6}",
                this.FirstName, this.LastName, this.FacultyNumber, this.PhoneNumber, this.Email, this.GetMarks(), this.Group);
        }

        private string GetMarks()
        {
            return String.Join(", ", this.Marks);
        }
    }
}
