using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace Contacts.ViewModels.Sidebar
{
    public partial class MainSidebarViewModel : ViewModelBase
    {
        [ObservableProperty]
        private ObservableCollection<SidebarItemViewModel> _sidebarItems = new ObservableCollection<SidebarItemViewModel>();


    }
}
