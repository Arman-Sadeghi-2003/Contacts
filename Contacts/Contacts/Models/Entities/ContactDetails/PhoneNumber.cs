using Contacts.Models.Enums;

namespace Contacts.Models.Entities.ContactDetails
{
    public class PhoneNumber
    {
        public long Id { get; set; }
        public long PersonId { get; set; }
        public long OrganizationId {  get; set; }

        public string TelPrefix { get; set; }
        public string Number { get; set; }
        public NumberCategories Category { get; set; }
    }
}
