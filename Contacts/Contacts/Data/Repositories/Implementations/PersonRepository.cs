using Contacts.Data.DataContext;
using Contacts.Data.Repositories.Interfaces;
using Contacts.Models.Entities;
using System.Collections.Generic;
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

        }

        public async Task DeletePerson(Person person)
        {

        }

        public async Task DeletePerson(long personId)
        {

        }

        public async Task EditPerson(Person person)
        {
            
        }

        public Task<List<Person>> GetAllPeople()
        {
            throw new System.NotImplementedException();
        }

        public Task<Person> GetPersonById(long Id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Person>> GetPersonsByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}
