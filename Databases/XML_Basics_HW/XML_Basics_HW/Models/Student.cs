using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_Basics_HW.Models
{
    public class Student
    {
        public Student()
        {

        }

        public string Name { get; set; }
        public string Sex { get; set; }
        public string Phone { get; set; }

        public override string ToString()
        {
            return $"{this.Name} -- {this.Sex} -- {this.Phone}";
        }
    }
}
