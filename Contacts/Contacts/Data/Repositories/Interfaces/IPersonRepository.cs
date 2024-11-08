using Contacts.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.Data.Repositories.Interfaces
{
    public interface IPersonRepository
    {
        Task AddPerson(Person person);
        Task EditPerson(Person person);
        Task DeletePerson(Person person);
        Task DeletePerson(long personId);
        Task<List<Person>> GetAllPeople();
        Task<List<Person>> GetPersonsByName(string name);
        Task<Person> GetPersonById(long Id);
    }
}
