using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem9_16_18
{
    public class Group
    {
        public int GroupNumber { get; private set; }
        public string DepartmentName { get; private set; }

        public Group(int groupNumber, string depName)
        {
            this.GroupNumber = groupNumber;
            this.DepartmentName = depName;
        }

        public override string ToString()
        {
            return String.Format($"Group number: {this.GroupNumber} \nDepartment: {this.DepartmentName}");
        }
    }
}
