using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace Contacts.ViewModels.Sidebar
{
    public partial class MainSidebarViewModel : ViewModelBase
    {
        [ObservableProperty]
        private ObservableCollection<SidebarItemViewModel> _sidebarItems = new ObservableCollection<SidebarItemViewModel>();

        public MainSidebarViewModel()
        {
            SidebarItems.Add(new SidebarItemViewModel()
            {

            });

            SidebarItems.Add(new SidebarItemViewModel()
            {

            });

            SidebarItems.Add(new SidebarItemViewModel()
            {

            });
        }

        [RelayCommand]
        private void AddContact()
        {

        }
    }
}
