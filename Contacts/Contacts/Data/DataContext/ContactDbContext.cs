using Contacts.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Data.DataContext
{
    public class ContactDbContext : DbContext
    {


        #region Db sets

        public DbSet<Person> People { get; set; }

        public DbSet<Organization> Organizations { get; set; }

        #endregion
    }
}
