using Contacts.Models.Entities;
using Contacts.Models.Entities.ContactDetails;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Data.DataContext
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext() { }

        public ContactDbContext(DbContextOptions<ContactDbContext> options)
           : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={ContactDbContextHandler.DbFullPath}");
        }

        #region Db sets

        public DbSet<Person> People { get; set; }

        public DbSet<Organization> Organizations { get; set; }
        
        public DbSet<Address> Addresses { get; set; }
        public DbSet<PhoneNumber> phoneNumbers { get; set; }
        public DbSet<Mail> mails { get; set; }


        #endregion
    }
}
