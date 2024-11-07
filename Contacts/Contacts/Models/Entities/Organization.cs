namespace Contacts.Models.Entities
{
    public class Organization
    {
        public long Id { get; set; }
        public long? PersonId { get; set; }

        public string Name { get; set; }
        public string Addreass { get; set; }
    }
}
