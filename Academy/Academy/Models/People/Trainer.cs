using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Models.Contracts;

namespace Academy.Models.People
{
    public class Trainer : User, ITrainer
    {
        private IList<string> technologies;

        public IList<string> Technologies
        {
            get
            {
                return new List<string>(this.technologies);
            }
            set
            {
                this.technologies = value;
            }
        }

        public Trainer(string username, string technologies) : base(username)
        {
            this.Technologies = new List<string>(technologies.Split(','));
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("* Trainer:\n");
            result.AppendFormat(base.ToString());
            result.AppendFormat($" - Technologies: {String.Join("; ", this.Technologies).TrimEnd()}");

            return result.ToString();
        }
    }
}
