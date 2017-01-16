using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Models.Contracts;
using Academy.Models.Enums;
using Academy.Models.Utils.Contracts;

namespace Academy.Models.People
{
    public class Student : User, IStudent
    {
        private Track track;
        private IList<ICourseResult> courseResults;

        public Track Track
        {
            get
            {
                return this.track;
            }
            set
            {
                // validation
                this.track = value;
            }
        }

        public IList<ICourseResult> CourseResults
        {
            get
            {
                return this.courseResults;// new List<ICourseResult>(this.courseResults);
            }
            set
            {
                this.courseResults = value;
            }
        }

        public Student(string username, string track) : base(username)
        {
            this.CourseResults = new List<ICourseResult>();
            if(track == "Frontend")
            {
                this.Track = Track.Frontend;
            }
            else if(track == "Dev")
            {
                this.Track = Track.Dev;
            }
            else if(track == "None")
            {
                this.Track = Track.None;
            }
            else
            {
                throw new InvalidOperationException("The provided track is not valid!");
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendFormat("* Student:\n");
            result.AppendFormat(base.ToString());
            result.AppendFormat($" - Track: {this.Track}\n");
            result.AppendFormat(" - Course results:\n");

            if(this.courseResults.Count == 0)
            {
                result.AppendFormat("  * User has no course results!\n");
            }
            else
            {
                result.AppendFormat($"{String.Join("\n", this.CourseResults)}");
            }

            return result.ToString();
        }
    }
}
