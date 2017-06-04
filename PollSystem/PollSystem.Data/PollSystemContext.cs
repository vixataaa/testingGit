using System.Data.Entity;
using PollSystem.Data.Models;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PollSystem.Data
{
    public class PollSystemContext : DbContext
    {
        public PollSystemContext()
            : base("PollSystemContext")
        {
        }

        public IDbSet<User> Users { get; set; }

        public IDbSet<City> Cities { get; set; }

        public IDbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            this.OnUserCreating(modelBuilder);
            this.OnCityCreating(modelBuilder);
            this.OnCountryCreating(modelBuilder);
        }

        private void OnUserCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(usr => usr.Username)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new IndexAttribute("IX_Username") { IsUnique = true }));

            modelBuilder.Entity<User>()
                .HasRequired(usr => usr.City)
                .WithMany(c => c.Users)
                .HasForeignKey(usr => usr.CityId);
        }

        private void OnCityCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new IndexAttribute("IX_Cityname") { IsUnique = true }));

            modelBuilder.Entity<City>()
                .HasRequired(c => c.Country)
                .WithMany(ctr => ctr.Cities)
                .HasForeignKey(c => c.CountryId);
        }

        private void OnCountryCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .Property(ctr => ctr.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new IndexAttribute("IX_Countryname") { IsUnique = true }));
        }
    }
}
