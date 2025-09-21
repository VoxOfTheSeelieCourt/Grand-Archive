using System;
using System.IO;
using System.Linq;
using System.Net.Mime;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Platform;
using Avalonia.Platform.Storage;
using GrandArchive.Models.Database;
using GrandArchive.Models.DnDTools;
using GrandArchive.Services;
using GrandArchive.Services.Navigation;
using GrandArchive.Services.UserInformationService;
using GrandArchive.ViewModels;
using GrandArchive.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GrandArchive.Helpers.ExtensionMethods;

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