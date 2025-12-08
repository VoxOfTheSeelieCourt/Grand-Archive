using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
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

    public ObservableCollection<NavigationBarEntry> NavigableViewModels => App.NavigableViewModels;

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

        SelectedNavigationBarEntry = NavigableViewModels.First();
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