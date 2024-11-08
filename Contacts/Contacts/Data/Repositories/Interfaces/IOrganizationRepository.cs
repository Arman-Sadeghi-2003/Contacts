using Contacts.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.Data.Repositories.Interfaces
{
    public interface IOrganizationRepository
    {
        Task AddOrganization(Organization organization);
        Task EditOrganization(Organization organization);
        Task DeleteOrganization(Organization organization);
        Task DeleteOrganization(long organizationId);
        Task<List<Organization>> GetAllOrganizations();
        Task<Organization> GetOrganizationByPersonId(long personId);
    }
}
