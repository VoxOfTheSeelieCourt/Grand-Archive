using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using GrandArchive.Helpers.Attributes;
using GrandArchive.Models;
using GrandArchive.Services.Navigation;
using GrandArchive.Services.UserInformationService;
using GrandArchive.ViewModels.Abstract;
using Microsoft.Extensions.DependencyInjection;

namespace GrandArchive.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private NavigationBarEntry _selectedNavigationBarEntry;

    private readonly IServiceProvider _serviceProvider;
    private readonly INavigationService _navigationService;
    private readonly IUserInformationMessageService _userInformationMessageService;

    public NavigableViewModel ActiveViewModel => _navigationService.ActiveViewModel;
    public ObservableCollection<UserMessageViewModel> UserMessageViewModels => _userInformationMessageService.UserMessageViewModels;

    public ObservableCollection<NavigationBarEntry> NavigableViewModels { get; }

    public MainWindowViewModel(INavigationService navigationService, IServiceProvider serviceProvider, IUserInformationMessageService userInformationMessageService)
    {
        _navigationService = navigationService;
        _serviceProvider = serviceProvider;
        _userInformationMessageService = userInformationMessageService;

        _navigationService.PropertyChanged += (_, args) =>
        {
            if (args.PropertyName == nameof(_navigationService.ActiveViewModel))
                OnPropertyChanged(nameof(ActiveViewModel));
        };

        NavigableViewModels = BuildNavigationBarEntries([
            typeof(SpellCardMainViewModel),
#if DEBUG
            typeof(ComponentDiagramViewModel),
            typeof(DnDDatabaseMigrationViewModel),
#endif
        ]);

        SelectedNavigationBarEntry = NavigableViewModels.First();
    }

    private ObservableCollection<NavigationBarEntry> BuildNavigationBarEntries(List<Type> types)
    {
        var output = new ObservableCollection<NavigationBarEntry>();
        Application.Current!.TryFindResource("DocumentErrorRegular", out var error);

        foreach (var type in types)
        {
            var data = type.GetCustomAttribute<NavigableMenuItemAttribute>();

            object i = null;
            if (data != null)
                Application.Current!.TryFindResource(data?.IconName, out i);

            var entry = new NavigationBarEntry
            {
                Type = type,
                Name = data?.Name ?? "ATTRIBUTE MISSING",
                Icon = (StreamGeometry)(i ?? error)
            };
            output.Add(entry);
        }

        return output;
    }

    private async Task<bool> ExecuteNavigateToPageCommand(Type pageType)
    {
        if (_navigationService == null
            || _serviceProvider.GetRequiredService(pageType) is not NavigableViewModel vm)
            return false;

        return await _navigationService.NavigateAsync(vm);
    }

    private async void OnNavigationChanged(NavigationBarEntry oldValue, NavigationBarEntry newValue)
    {
        if (!await ExecuteNavigateToPageCommand(newValue.Type))
            SelectedNavigationBarEntry = oldValue;
    }

    partial void OnSelectedNavigationBarEntryChanged(NavigationBarEntry oldValue, NavigationBarEntry newValue)
    {
        OnNavigationChanged(oldValue, newValue);
    }
}