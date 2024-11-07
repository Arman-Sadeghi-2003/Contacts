using Contacts.Models.Enums;

namespace Contacts.Models.Entities.ContactDetails
{
    public class Mail
    {
        public long Id { get; set; }
        public long PersonId { get; set; }
        public long OrganizationId { get; set; }

        public string MailAddress { get; set; }
        public MailCategories Category { get; set; }
    }
}
