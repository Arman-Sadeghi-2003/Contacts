using Contacts.Data.Repositories.Interfaces;

namespace Contacts.ViewModels.Adders
{
    public partial class AddNewContactViewModel : ViewModelBase
    {
        private readonly IPersonRepository personRepo;
        private readonly IPhoneNumberRepository phoneNumberRepo;
        private readonly IMailRepository mailRepo;
        private readonly IAddressRepository AddressRepo;
        private readonly IOrganizationRepository organizationRepo;

        public AddNewContactViewModel(IPersonRepository personRepo, IPhoneNumberRepository phoneNumberRepo, IMailRepository mailRepo,
                                      IAddressRepository AddressRepo, IOrganizationRepository organizationRepo)
        {
            this.personRepo = personRepo;
            this.phoneNumberRepo = phoneNumberRepo;
            this.mailRepo = mailRepo;
            this.AddressRepo = AddressRepo;
            this.organizationRepo = organizationRepo;
        }



    }
}
