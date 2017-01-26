using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    public class ClassOfStudents : ICommentable
    {
        private int uniqueStudentID;
        private List<string> comments;
        private List<Teacher> teachers;
        private List<Student> students;
        public string ClassName { get; private set; }   //textID

        public List<string> Comments
        {
            get
            {
                return new List<string>(this.comments);
            }
            private set
            {
                this.comments = value;
            }
        }

        public List<Teacher> Teachers
        {
            get
            {
                return new List<Teacher>(this.teachers);
            }
            private set
            {
                this.teachers = value;
            }
        }

        public List<Student> Students
        {
            get
            {
                return new List<Student>(this.students);
            }
            private set
            {
                this.students = value;
            }

        }

        public ClassOfStudents(string className, params string[] comments)
        {
            this.ClassName = className;
            this.Comments = new List<string>(comments);
            this.Teachers = new List<Teacher>();
            this.Students = new List<Student>();
            this.uniqueStudentID = 1;
        }

        public void AddComment(string text)
        {
            this.comments.Add(text);
        }

        //add student
        public void AddStudent(Student student)
        {
            //adds student, gives him an uniqueID
            this.students.Add(student);
            student.UniqueID = this.uniqueStudentID;
            this.uniqueStudentID++;
        }

        //add teacher
        public void AddTeacher(Teacher teacher)
        {
            this.teachers.Add(teacher);
        }

        //remove student
        public void RemoveStudent(Student student)
        {
            this.students.Remove(student);
            student.UniqueID = 0;   //frees the uniqueID
        }

        //remove teacher
        public void RemoveTeacher(Teacher teacher)
        {
            this.teachers.Remove(teacher);
        }

        public override string ToString()
        {
            return String.Format("\n*Name: {0} \n*Comments: {1} \n+Teachers: \n{2} \n+Students: \n{3}",
                this.ClassName, String.Join(", ", this.Comments), String.Join("\n", this.teachers), String.Join("\n", this.students));
        }
    }
}
