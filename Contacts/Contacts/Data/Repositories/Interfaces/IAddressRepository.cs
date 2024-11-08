using Contacts.Models.Entities.ContactDetails;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.Data.Repositories.Interfaces
{
    public interface IAddressRepository
    {
        Task AddAddress(Address address);
        Task EditAddress(Address address);
        Task DeleteAddress(Address address);
        Task DeleteAddress(long addressId);
        Task<List<Address>> GetAllAddresses();
        Task<List<Address>> GetAddressesByPersonId(long personId);
    }
}
