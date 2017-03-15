using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models.People
{
    public abstract class User : IUser
    {
        private string username;

        public string Username
        {
            get
            {
                return this.username;
            }
            set
            {
                if(value.Length < 3 || value.Length > 16)
                {
                    throw new InvalidOperationException("User's username should be between 3 and 16 symbols long!");
                }
                this.username = value;
            }
        }

        public User(string username)
        {
            this.Username = username;
        }

        public override string ToString()
        {
            return string.Format($" - Username: {this.Username}\n");
        }
    }
}
