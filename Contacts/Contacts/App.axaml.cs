using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using CommunityToolkit.Mvvm.DependencyInjection;
using Contacts.Data.DataContext;
using Contacts.ViewModels;
using Contacts.ViewModels.Sidebar;
using Contacts.Views;
using Contacts.Views.Sidebar;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

namespace Contacts
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public async override void OnFrameworkInitializationCompleted()
        {
            if (!Directory.Exists(ContactDbContextHandler.ContactLocalDirectory))
                Directory.CreateDirectory(ContactDbContextHandler.ContactLocalDirectory);

            var locator = new ViewLocator();
            DataTemplates.Add(locator);

            var services = new ServiceCollection();

            services.AddDbContext<ContactDbContext>(options =>
            {
                options.UseSqlite($"Data Source={ContactDbContextHandler.DbFullPath}");
            }, ServiceLifetime.Singleton);

            using (var scope = services.BuildServiceProvider().CreateScope())
            {

                var dbContext = scope.ServiceProvider.GetRequiredService<ContactDbContext>();
                var pendingMigration = dbContext.Database.GetPendingMigrations();

                if (pendingMigration.Any())
                {
                    try
                    {
                        await dbContext.Database.MigrateAsync();
                    }
                    catch
                    {
                        dbContext.Database.EnsureDeleted();
                        await dbContext.Database.MigrateAsync();
                    }
                }
            }

            ConfigureViewModels(services);
            ConfigureViews(services);

            var provider = services.BuildServiceProvider();

            Ioc.Default.ConfigureServices(provider);

            var vm = Ioc.Default.GetRequiredService<MainViewModel>();

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                BindingPlugins.DataValidators.RemoveAt(0);
                desktop.MainWindow = new MainWindow
                {
                    DataContext = vm,
                };
            }
            else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
            {
                singleViewPlatform.MainView = new MainView
                {
                    DataContext = vm,
                };
            }

            base.OnFrameworkInitializationCompleted();
        }

        [SuppressMessage("CommunityToolkit.Extensions.DependencyInjection.SourceGenerators.InvalidServiceRegistrationAnalyzer", "TKEXDI0004:Duplicate service type registration")]
        internal static void ConfigureViewModels(IServiceCollection services)
        {
            services.AddSingleton(typeof(MainViewModel));
            services.AddTransient(typeof(MainSidebarViewModel));
        }

        internal static void ConfigureViews(IServiceCollection services)
        {
            services.AddSingleton(typeof(MainWindow));
            services.AddTransient(typeof(MainSidebarView));
        }

    }
}