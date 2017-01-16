using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Models.Resources.Abstract;
using Academy.Models.Utils.Contracts;
using Academy.Models.Contracts;


namespace Academy.Models.Resources
{
    class PresentationResource : LectureResource, ILectureResouce
    {

        public PresentationResource(string name, string url) : base(name, url)
        {

        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendFormat($"    * Resource:\n");
            result.AppendFormat($"     - Name: {this.Name}\n");
            result.AppendFormat($"     - Url: {this.Url}\n");
            result.AppendFormat($"     - Type: Presentation");

            return result.ToString();

            //    * Resource:
            //  -Name: < name >
            // -Url: < url >
            //-Type: Demo
        }
    }
}
