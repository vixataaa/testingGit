using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    public class School
    {
        private List<ClassOfStudents> classes;

        public List<ClassOfStudents> Classes
        {
            get
            {
                return new List<ClassOfStudents>(classes);
            }
            private set
            {
                this.classes = value;
            }
        }

        public string SchoolName { get; private set; }

        public School(string name, params ClassOfStudents[] classes)
        {
            this.SchoolName = name;
            this.Classes = new List<ClassOfStudents>(classes);
        }

        public override string ToString()
        {
            return String.Format("School name: {0} \nClasses: \n{1}",
                this.SchoolName, String.Join("\n", this.Classes));
        }

        public void AddClass(ClassOfStudents studentClass)
        {
            this.classes.Add(studentClass);
        }

        public void RemoveClass(ClassOfStudents studentClass)
        {
            this.classes.Remove(studentClass);
        }
    }
}
