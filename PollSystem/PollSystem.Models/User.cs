namespace PollSystem.Data.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public virtual City City { get; set; }

        public virtual int CityId { get; set; }
    }
}