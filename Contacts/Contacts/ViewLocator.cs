using Avalonia.Controls;
using Avalonia.Controls.Templates;
using CommunityToolkit.Mvvm.DependencyInjection;
using Contacts.ViewModels;
using Contacts.ViewModels.Sidebar;
using Contacts.Views;
using Contacts.Views.Sidebar;
using System;
using System.Collections.Generic;

namespace Contacts
{
    public class ViewLocator : IDataTemplate
    {
        private readonly Dictionary<Type, Func<Control?>> _locator = new();

        public ViewLocator()
        {
            RegisterViewFactory<MainViewModel, MainWindow>();
            RegisterViewFactory<MainSidebarViewModel, MainSidebarView>();
            RegisterViewFactory<SidebarItemViewModel, SidebarItemView>();
        }

        public Control? Build(object? data)
        {
            if (data is null)
                return null;

            var name = data.GetType().FullName!.Replace("ViewModel", "View", StringComparison.Ordinal);
            var type = Type.GetType(name);

            if (type != null)
            {
                return (Control)Activator.CreateInstance(type)!;
            }

            return new TextBlock { Text = "Not Found: " + name };
        }

        public bool Match(object? data)
        {
            return data is ViewModelBase;
        }


        private void RegisterViewFactory<TViewModel, TView>()
        where TViewModel : class
        where TView : Control
        => _locator.Add(
            typeof(TViewModel),
            Design.IsDesignMode
                ? Activator.CreateInstance<TView>
                : Ioc.Default.GetService<TView>);

    }
}