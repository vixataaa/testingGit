using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Models.Contracts;
using Academy.Models.Resources.Abstract;

namespace Academy.Models.Resources
{
    public class DemoResource : LectureResource, ILectureResouce
    {
        public DemoResource(string name, string url) : base(name,url)
        {

        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendFormat($"    * Resource:\n");
            result.AppendFormat($"     - Name: {this.Name}\n");
            result.AppendFormat($"     - Url: {this.Url}\n");
            result.AppendFormat($"     - Type: Demo");

            return result.ToString();

            //    * Resource:
            //  -Name: < name >
            // -Url: < url >
            //-Type: Demo
        }
    }
}
