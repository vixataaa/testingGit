using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    public class Teacher : Person
    {
        private List<Discipline> disciplines;

        public List<Discipline> Disciplines
        {
            get
            {
                return new List<Discipline>(this.disciplines);
            }
            private set
            {
                this.disciplines = value;
            }
        }

        public Teacher(string name, params string[] comments) : base(name, comments)
        {
            this.disciplines = new List<Discipline>();
        }

        public void AddDiscipline(Discipline discipline)
        {
            this.disciplines.Add(discipline);
        }

        public override string ToString()
        {
            return String.Format("  -Teacher - {0}\n    *Disciplines \n{1}", base.ToString(), String.Join("\n", this.disciplines));
        }

    }
}
