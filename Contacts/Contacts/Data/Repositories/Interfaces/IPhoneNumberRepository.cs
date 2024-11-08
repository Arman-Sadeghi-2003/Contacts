using Contacts.Models.Entities.ContactDetails;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.Data.Repositories.Interfaces
{
    public interface IPhoneNumberRepository
    {
        Task AddPhoneNumber(PhoneNumber number);
        Task EditePhoneNumber(PhoneNumber number);
        Task DeletePhoneNumber(PhoneNumber number);
        Task DeletePhoneNumber(long numberId);
        Task<List<PhoneNumber>> GetAll();
        Task<List<PhoneNumber>> GetPhoneNumbersbyPersonId(long personId);
        Task<List<PhoneNumber>> GetPhoneNumbersByOrganizationId(long organizationId);

    }
}
