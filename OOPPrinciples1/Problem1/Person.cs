using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    public abstract class Person : ICommentable
    {
        private List<string> comments;

        public string Name { get; private set; }

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

        public Person(string name, params string[] comments)
        {
            this.Name = name;
            this.comments = new List<string>(comments);
        }

        public void AddComment(string text)
        {
            this.comments.Add(text);
        }

        public override string ToString()
        {
            return String.Format("{0} -- {1}", this.Name, String.Join(", ", this.comments));
        }
    }
}
