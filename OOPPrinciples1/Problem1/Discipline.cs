using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    public class Discipline : ICommentable
    {
        public string Name { get; private set; }
        public uint NumberLectures { get; private set; }
        public uint NumberExercises { get; private set; }
        private List<string> comments;

        public List<string> Comments
        {
            get
            {
                return new List<string>(comments);
            }
            private set
            {
                this.comments = value;
            }
        }

        public Discipline(string name, uint numberLectures, uint numberExercises, params string[] comments)
        {
            this.Name = name;
            this.NumberLectures = numberLectures;
            this.NumberExercises = numberExercises;
            this.Comments = new List<string>(comments);
        }

        public void AddComment(string text)
        {
            this.comments.Add(text);
        }

        public override string ToString()
        {
            return String.Format("     -{0} - {1} -- Lect: {2} -- Exc: {3}",
                this.Name, String.Join(", ", this.comments), this.NumberLectures, this.NumberExercises);
        }
    }
}
