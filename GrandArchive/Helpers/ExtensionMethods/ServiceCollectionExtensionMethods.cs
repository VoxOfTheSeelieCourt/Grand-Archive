using GrandArchive.Services;
using GrandArchive.Services.Navigation;
using GrandArchive.Services.UserInformationService;
using GrandArchive.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace GrandArchive.Helpers.ExtensionMethods;

public static class ServiceCollectionExtensionMethods
{
    public static void Configure(this IServiceCollection s)
    {
        // View Models
        s.AddSingleton<MainWindowViewModel>();
        s.AddSingleton<SpellCardMainViewModel>();
        s.AddSingleton<ComponentDiagramViewModel>();

        // Services
        s.AddSingleton<INavigationService, NavigationService>();
        s.AddSingleton<IDispatcherService, DispatcherService>();
        s.AddSingleton<IUserInformationMessageService, ViewModelUserInformationMessageService>();

        // Delegates
        s.AddSingleton<CreateUserMessageViewModel>(provider =>
            (message, type, after, details) =>
                new UserMessageViewModel(message, type, after, details, provider.GetRequiredService<IUserInformationMessageService>()));
    }
}