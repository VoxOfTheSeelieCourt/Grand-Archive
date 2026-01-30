using GrandArchive.Helpers.Attributes;
using GrandArchive.Models.Configuration;
using GrandArchive.Services;
using GrandArchive.ViewModels.Abstract;

namespace GrandArchive.ViewModels;

[NavigableMenuItem("Settings", "SettingsRegular")]
public partial class SettingsViewModel : NavigableViewModel
{
    private readonly IConfigurationService _configurationService;
    
    public IGrandArchiveSettings GrandArchiveSettings => _configurationService.GrandArchiveSettings;

    public SettingsViewModel(IConfigurationService configurationService)
    {
        _configurationService = configurationService;
    }
}