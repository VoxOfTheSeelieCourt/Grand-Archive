using System;
using System.IO;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using GrandArchive.Models.Database;
using GrandArchive.Models.DnDTools;
using GrandArchive.Services;
using GrandArchive.Services.Navigation;
using GrandArchive.Services.UserInformationService;
using GrandArchive.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GrandArchive.Helpers.ExtensionMethods;
public delegate TopLevel GetTopLevel();

public static class ServiceCollectionExtensionMethods
{
    public static void Configure(this IServiceCollection s)
    {
        // Database
        s.AddDbContextFactory<DndContext>();
        s.AddDbContextFactory<DatabaseContext>();

        // View Models
        s.AddSingleton<MainWindowViewModel>();
        s.AddSingleton<SpellCardMainViewModel>();
        s.AddSingleton<ComponentDiagramViewModel>();
        s.AddSingleton<DnDDatabaseMigrationViewModel>();

        // Services
        s.AddSingleton<INavigationService, NavigationService>();
        s.AddSingleton<IDispatcherService, DispatcherService>();
        s.AddSingleton<IUserInformationMessageService, ViewModelUserInformationMessageService>();

        // Delegates
        s.AddSingleton<CreateUserMessageViewModel>(provider =>
            (message, type, after, details) =>
                new UserMessageViewModel(message, type, after, details, provider.GetRequiredService<IUserInformationMessageService>()));
        s.AddSingleton<GetTopLevel>(_ => () =>
        {
            return Application.Current?.ApplicationLifetime switch
            {
                IClassicDesktopStyleApplicationLifetime desk => desk.Windows.FirstOrDefault(w => w.IsActive) ?? desk.MainWindow,
                ISingleViewApplicationLifetime single => TopLevel.GetTopLevel(single.MainView),
                _ => null
            };
        });
    }

    public static IServiceProvider InitDatabase<T>(this IServiceProvider serviceProvider) where T : DbContext
    {
        var contextFactory = serviceProvider.GetRequiredService<IDbContextFactory<T>>();

        using var context = contextFactory.CreateDbContext();
        Directory.CreateDirectory(Path.GetDirectoryName(context.Database.GetDbConnection().DataSource));
        context.Database.Migrate();

        return serviceProvider;
    }
}