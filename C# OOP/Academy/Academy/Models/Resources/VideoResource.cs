using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Models.Resources.Abstract;
using Academy.Models.Contracts;

namespace Academy.Models.Resources
{
    public class VideoResource : LectureResource, ILectureResouce
    {
        private DateTime uploadedOn;

        public DateTime UploadedOn
        {
            get
            {
                return this.uploadedOn;
            }
            set
            {
                this.uploadedOn = value;
            }
        }

        public VideoResource(string name, string url, DateTime uploadedOn) : base(name, url)
        {
            this.UploadedOn = uploadedOn;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendFormat($"    * Resource:\n");
            result.AppendFormat($"     - Name: {this.Name}\n");
            result.AppendFormat($"     - Url: {this.Url}\n");
            result.AppendFormat($"     - Type: Video\n");
            result.AppendFormat($"     - Uploaded on: {this.UploadedOn}");

            return result.ToString();

            //    * Resource:
            //  -Name: < name >
            // -Url: < url >
            //-Type: Demo
        }
    }
}
