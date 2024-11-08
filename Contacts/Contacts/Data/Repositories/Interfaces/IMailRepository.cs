using Contacts.Models.Entities.ContactDetails;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.Data.Repositories.Interfaces
{
    public interface IMailRepository
    {
        Task AddMail(Mail mail);
        Task EditMail(Mail mail);
        Task DeleteMail(Mail mail);
        Task DeleteMail(long mailId);
        Task<List<Mail>> GetAllMails();
        Task<List<Mail>> GetAllMailsByPersonId(long personId);
        Task<List<Mail>> GetAllMailsByOrganizationId(long organizationId);
    }
}
