using Microsoft.EntityFrameworkCore;
using System;
using TopContactsAPI.Model;

namespace TopContactsAPI.Data
{
    public class ContactsContext : DbContext
    {
        public ContactsContext(DbContextOptions<ContactsContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Profile> Profiles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Guid mainProfileId = Guid.NewGuid();

            var profile = builder.Entity<Profile>()
                   .HasData(new Profile(mainProfileId, "Main Profile", "mainprofile@mail.com", "51999000111"));

            builder.Entity<Contact>()
                  .HasData(new Contact(Guid.NewGuid(), "John", "Smith", "johnsmith@mail.com", "5400112244", true, mainProfileId));

        }
    }
}
