using GrandArchive.Models.Configuration;

namespace GrandArchive.Services;

/// <summary>
/// Manages local user configuration, mostly user settings from <see cref="SettingsViewModel"/>.
/// </summary>
/// <remarks>Uses <a href="https://github.com/aloneguid/config">Config.net</a> to read, store and write settings.</remarks>
public interface IConfigurationService
{
    /// <summary>
    /// The ConfigurationTreeRoot.
    /// </summary>
    IGrandArchiveSettings GrandArchiveSettings { get; set; }

    /// <summary>
    /// Method called to apply all settings to the application. Automatically called at startup in <see cref="App.OnStartup"/>.
    /// </summary>
    void InitializeConfiguration();
}