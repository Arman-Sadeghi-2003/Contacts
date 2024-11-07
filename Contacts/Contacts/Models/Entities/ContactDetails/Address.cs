namespace Contacts.Models.Entities.ContactDetails
{
    public class Address
    {
        public long Id { get; set; }
        public long PersonId { get; set; }

        public string Content { get; set; }

    }
}
