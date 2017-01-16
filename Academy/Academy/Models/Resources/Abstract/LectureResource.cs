using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Models.Contracts;

namespace Academy.Models.Resources.Abstract
{
    public abstract class LectureResource : ILectureResouce
    {
        private string name;
        private string url;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value.Length < 3 || value.Length > 15)
                {
                    throw new InvalidOperationException("Resource name should be between 3 and 15 symbols long!");
                }
                this.name = value;
            }
        }

        public string Url
        {
            get
            {
                return this.url;
            }
            set
            {
                if (value.Length < 5 || value.Length > 150)
                {
                    throw new InvalidOperationException("Resource url should be between 5 and 150 symbols long!");
                }

                this.url = value;
            }
        }

        public LectureResource(string name, string url)
        {
            this.Name = name;
            this.Url = url;
        }

        //toString to be inherited too but no time...
    }
}
