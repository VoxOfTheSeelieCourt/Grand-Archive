using System.IO;
using GrandArchive.Helpers;
using GrandArchive.Models.Configuration;

namespace GrandArchive.Services;

/// <inheritdoc />
public class ConfigurationService(IGrandArchiveSettings grandArchiveSettings) : IConfigurationService
{
    /// <inheritdoc />
    public IGrandArchiveSettings GrandArchiveSettings { get; set; } = grandArchiveSettings;

    /// <inheritdoc />
    public void InitializeConfiguration()
    {
        if (string.IsNullOrEmpty(GrandArchiveSettings.DatabaseConnectionString)) GrandArchiveSettings.DatabaseConnectionString = Path.Combine(DataLocationHelper.GetRootFolder(), "Database.sqlite");
        if (string.IsNullOrEmpty(GrandArchiveSettings.DndToolsConnectionString)) GrandArchiveSettings.DndToolsConnectionString = Path.Combine(DataLocationHelper.GetRootFolder(), "dnd.sqlite");
    }
}