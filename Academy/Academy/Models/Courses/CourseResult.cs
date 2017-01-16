using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Models.Utils.Contracts;
using Academy.Models.Contracts;
using Academy.Models.Enums;

namespace Academy.Models.Courses
{
    class CourseResult : ICourseResult
    {
        private ICourse course;
        private float examPoints;
        private float coursePoints;
        private Grade grade;

        public ICourse Course
        {
            get
            {
                return this.course;
            }
            set
            {
                // validation
                this.course = value;
            }
        }

        public float ExamPoints
        {
            get
            {
                return this.examPoints;
            }
            set
            {
                if(value < 0 || value > 1000)
                {
                    throw new InvalidOperationException("Course result's exam points should be between 0 and 1000!");
                }
                this.examPoints = value;
            }
        }

        public float CoursePoints
        {
            get
            {
                return this.coursePoints;
            }
            set
            {
                if(value < 0 || value > 125)
                {
                    throw new InvalidOperationException("Course result's course points should be between 0 and 125!");
                }
                this.coursePoints = value;
            }
        }

        public Grade Grade
        {
            get
            {
                return this.grade;
            }
            set
            {
                //validation, calculation based on points
                this.grade = value;
            }
        }

        public CourseResult(ICourse course, string examPoints, string coursePoints)
        {
            this.Course = course;
            this.ExamPoints = float.Parse(examPoints);
            this.CoursePoints = float.Parse(coursePoints);
            this.Grade = this.CalculateGrade();
        }

        private Grade CalculateGrade()
        {
            if(this.ExamPoints >= 65 || this.CoursePoints >= 75)
            {
                return Grade.Excellent;
            }
            else if((this.ExamPoints >= 30 && this.ExamPoints < 60) ||
                (this.CoursePoints < 75 && this.CoursePoints >= 45))
            {
                return Grade.Passed;
            }
            else
            {
                return Grade.Failed;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendFormat($"  * {this.Course.Name}: Points - {this.CoursePoints}, Grade - {this.Grade}");

            return result.ToString();
        }

    }
}
