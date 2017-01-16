using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Models.Contracts;
using Academy.Models.Resources.Abstract;

namespace Academy.Models.Resources
{
    class HomeworkResource : LectureResource, ILectureResouce
    {
        private DateTime dueDate;

        public DateTime DueDate
        {
            get
            {
                return this.dueDate;
            }
            set
            {
                this.dueDate = value;
            }
        }

        public HomeworkResource(string name, string url, DateTime dueDate) : base(name, url)
        {
            this.DueDate = dueDate;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendFormat($"    * Resource:\n");
            result.AppendFormat($"     - Name: {this.Name}\n");
            result.AppendFormat($"     - Url: {this.Url}\n");
            result.AppendFormat($"     - Type: Homework\n");
            result.AppendFormat($"     - Due date: {this.DueDate}");

            return result.ToString();

            //    * Resource:
            //  -Name: < name >
            // -Url: < url >
            //-Type: Demo
        }
    }
}
