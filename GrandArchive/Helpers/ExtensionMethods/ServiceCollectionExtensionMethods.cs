using System;
using System.IO;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Config.Net;
using GrandArchive.Models.Configuration;
using GrandArchive.Models.Database;
using GrandArchive.Models.DnDTools;
using GrandArchive.Services;
using GrandArchive.Services.Navigation;
using GrandArchive.Services.UserInformationService;
using GrandArchive.ViewModels;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GrandArchive.Helpers.ExtensionMethods;
public delegate TopLevel GetTopLevel();

public static class ServiceCollectionExtensionMethods
{
    public static void Configure(this IServiceCollection s)
    {
        string configPath = SetupConfigPath();

        // Config
        s.AddSingleton(_ => new ConfigurationBuilder<IGrandArchiveSettings>().UseJsonFile(configPath).Build());
        
        // Database
        s.AddDbContext<DndContext>((b, x) => ConfigureDbContext(x, b.GetRequiredService<IGrandArchiveSettings>().DndToolsConnectionString));
        s.AddDbContext<DatabaseContext>((b, x) => ConfigureDbContext(x, b.GetRequiredService<IGrandArchiveSettings>().DatabaseConnectionString));

        // View Models
        s.AddSingleton<MainWindowViewModel>();
        s.AddSingleton<SpellCardMainViewModel>();
        s.AddSingleton<ComponentDiagramViewModel>();
        s.AddSingleton<DnDDatabaseMigrationViewModel>();
        s.AddSingleton<SettingsViewModel>();

        // Services
        s.AddSingleton<INavigationService, NavigationService>();
        s.AddSingleton<IDispatcherService, DispatcherService>();
        s.AddSingleton<IUserInformationMessageService, ViewModelUserInformationMessageService>();
        s.AddSingleton<IConfigurationService, ConfigurationService>();

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

    private static string SetupConfigPath()
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "config.json");
        Directory.CreateDirectory(Path.GetDirectoryName(path) ?? throw new NullReferenceException($"Cannot get path from {path}"));
        if (!File.Exists(path))
        {
            using var file = File.CreateText(path);
            file.WriteLine("{}");
        }

        return path;
    }

    private static void ConfigureDbContext(DbContextOptionsBuilder optionsBuilder, string path)
    {
        var connectionStringBuilder = new SqliteConnectionStringBuilder
        {
            DataSource = path,
            Mode = SqliteOpenMode.ReadWriteCreate,
            // Cache = SqliteCacheMode.Shared,
        };

        optionsBuilder.UseSqlite(connectionStringBuilder.ConnectionString);
    }

    public static IServiceProvider InitDatabase<T>(this IServiceProvider serviceProvider) where T : DbContext
    {
        var context = serviceProvider.GetRequiredService<T>();

        Directory.CreateDirectory(Path.GetDirectoryName(context.Database.GetDbConnection().DataSource));
        context.Database.Migrate();

        return serviceProvider;
    }
}