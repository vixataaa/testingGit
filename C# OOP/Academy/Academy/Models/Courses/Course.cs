using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Models.Contracts;

namespace Academy.Models.Courses
{
    public class Course : ICourse
    {
        private string name;
        private int lecturesPerWeek;
        private DateTime startingDate;
        private DateTime endingDate;
        private IList<IStudent> onsiteStudents;
        private IList<IStudent> onlineStudents;
        private IList<ILecture> lectures;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if(value.Length < 3 || value.Length > 42)
                {
                    throw new InvalidOperationException("The name of the course must be between 3 and 45 symbols!");
                }
                this.name = value;
            }
        }

        public int LecturesPerWeek
        {
            get
            {
                return this.lecturesPerWeek;
            }
            set
            {
                if(value < 1 || value > 7)
                {
                    throw new InvalidOperationException("The number of lectures per week must be between 1 and 7!");
                }
                this.lecturesPerWeek = value;
            }
        }

        public DateTime StartingDate
        {
            get
            {
                return this.startingDate;
            }
            set
            {
                this.startingDate = value;
            }
        }

        public DateTime EndingDate
        {
            get
            {
                return this.endingDate;
            }
            set
            {
                this.endingDate = value;
            }
        }

        public IList<IStudent> OnsiteStudents
        {
            get
            {
                return this.onsiteStudents;//new List<IStudent>(this.onsiteStudents);
            }
            set
            {
                this.onsiteStudents = value;
            }
        }

        public IList<IStudent> OnlineStudents
        {
            get
            {
                return this.onlineStudents;//new List<IStudent>(this.onlineStudents);
            }
            set
            {
                this.onlineStudents = value;
            }
        }

        public IList<ILecture> Lectures
        {
            get
            {
                return this.lectures;//new List<ILecture>(this.lectures);
            }
            set
            {
                this.lectures = value;
            }
        }

        public Course(string name, string lecturesPerWeek, string startingDate)
        {
            this.Name = name;
            this.LecturesPerWeek = int.Parse(lecturesPerWeek);
            this.StartingDate = DateTime.Parse(startingDate);
            this.OnsiteStudents = new List<IStudent>();
            this.OnlineStudents = new List<IStudent>();
            this.EndingDate = this.StartingDate.Add(new TimeSpan(30, 0, 0, 0));
            this.Lectures = new List<ILecture>();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendFormat("* Course:\n");
            result.AppendFormat($" - Name: {this.Name}\n");
            result.AppendFormat($" - Lectures per week: {this.LecturesPerWeek}\n");
            result.AppendFormat(" - Starting date: {0:M\\/dd\\/yyyy hh:mm:ss tt}\n", this.StartingDate);
            result.AppendFormat(" - Ending date: {0:M\\/dd\\/yyyy hh:mm:ss tt}\n", this.EndingDate);
            result.AppendFormat($" - Onsite students: {this.onsiteStudents.Count}\n");
            result.AppendFormat($" - Online students: {this.onlineStudents.Count}\n");

            result.AppendFormat($" - Lectures:\n");

            if (this.lectures.Count == 0)
            {
                result.AppendFormat("  * There are no lectures in this course!\n");
            }
            else
            {
                result.AppendFormat($"{string.Join("\n", this.lectures)}");
            }

            return result.ToString();
        }
    }
}
