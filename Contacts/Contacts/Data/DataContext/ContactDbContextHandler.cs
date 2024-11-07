using System;
using System.IO;

namespace Contacts.Data.DataContext
{
    public class ContactDbContextHandler
    {
        public static readonly string ContactLocalDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AILC_Contacts");

        public static readonly string DbFullPath = Path.Combine(ContactLocalDirectory, "AILC_Contacts_database.db");
    }
}
