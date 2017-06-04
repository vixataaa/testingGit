using System.Collections.Generic;

namespace PollSystem.Data.Models
{
    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Country Country { get; set; }

        public virtual int CountryId { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}