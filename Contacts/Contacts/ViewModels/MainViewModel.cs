using CommunityToolkit.Mvvm.ComponentModel;
using Contacts.ViewModels.Home;
using Contacts.ViewModels.Sidebar;

namespace Contacts.ViewModels
{
    public partial class MainViewModel : ViewModelBase
    {
        [ObservableProperty]
        private ViewModelBase _sidebarControl;

        [ObservableProperty]
        private ViewModelBase _centerControl;

        public MainViewModel()
        {
            SidebarControl = new MainSidebarViewModel();
            CenterControl = new HomeViewModel();
        }
    }
}
