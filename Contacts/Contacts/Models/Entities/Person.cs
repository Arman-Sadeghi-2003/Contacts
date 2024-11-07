namespace Contacts.Models.Entities
{
    public class Person
    {
        public long Id { get; set; }
        public string NamePrefix { get; set; }
        public string Firstname { get; set; }
        public string MiddleName { get; set; }
        public string Lastname { get; set; }
        public string NameSuffix { get; set; }
        public byte[] Avatar { get; set; }
    }
}
