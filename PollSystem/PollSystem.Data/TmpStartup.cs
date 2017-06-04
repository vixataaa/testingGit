using PollSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollSystem.Data
{
    class TmpStartup
    {
        public static void Main()
        {
            var ctx = new PollSystemContext();


            var country = new Country()
            {
                Name = "Bulgaria"
            };

            //ctx.Countries.Attach(country);
            ctx.Entry<Country>(country).State = EntityState.Modified;
            ctx.SaveChanges();


            var city = new City()
            {
                Name = "Sofia",
                Country = country
            };

            var user = new User()
            {
                Username = "user2",
                City = city
            };

            //ctx.Users.Add(user);
            //ctx.SaveChanges();
        }
    }
}
