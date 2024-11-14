using Contacts.Data.DataContext;
using Contacts.Data.Repositories.Interfaces;
using Contacts.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Data.Repositories.Implementations
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ContactDbContext context;

        public PersonRepository(ContactDbContext context)
        {
            this.context = context;
        }

        public async Task AddPerson(Person person)
        {
            try
            {
                await context.People.AddAsync(person);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                new MessageBoxView("Error for Add new person in Db", ex.Message).Show();
            }
        }

        public async Task DeletePerson(Person person)
        {
            try
            {
                context.People.Remove(person);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                new MessageBoxView("Error for Remove the person at Db", ex.Message).Show();
            }
        }

        public async Task DeletePerson(long personId)
        {
            try
            {
                var p = await context.People.FindAsync(personId);
                if (p != null)
                {
                    context.People.Remove(p);
                    await context.SaveChangesAsync();
                }
                else
                {
                    new MessageBoxView("Error for Remove the person at Db", "Not found Person").Show();
                }
            }
            catch (Exception ex)
            {
                new MessageBoxView("Error for Remove the person at Db", ex.Message).Show();
            }
        }

        public async Task EditPerson(Person person)
        {
            try
            {
                var p = await context.People.Where(p => p.Id == person.Id).FirstOrDefaultAsync();
                if (p != null)
                {
                    p.NamePrefix = person.NamePrefix;
                    p.Firstname = person.Firstname;
                    p.MiddleName = person.MiddleName;
                    p.Lastname = person.Lastname;
                    p.NameSuffix = person.NameSuffix;
                    p.Avatar = person.Avatar;

                    context.People.Update(p);
                    await context.SaveChangesAsync();
                }
                else
                {
                    new MessageBoxView("Error for Edit person from Db", "Not found Person").Show();
                }
            }
            catch (Exception ex)
            {
                new MessageBoxView("Error for Edit person from Db", ex.Message).Show();
            }
        }

        public async Task<List<Person>> GetAllPeople()
        {
            return await context.People.ToListAsync();
        }

        public async Task<Person> GetPersonById(long Id)
        {
            return await context.People.FindAsync(Id) ?? new Person();
        }

        public async Task<List<Person>> GetPersonsByName(string name)
        {
            return await context.People.Where(p => (p.NamePrefix ?? "").Contains(name) || (p.Firstname ?? "").Contains(name) || (p.MiddleName ?? "").Contains(name) ||
                                                   (p.Lastname ?? "").Contains(name) || (p.NameSuffix ?? "").Contains(name)).ToListAsync();
        }
    }
}
