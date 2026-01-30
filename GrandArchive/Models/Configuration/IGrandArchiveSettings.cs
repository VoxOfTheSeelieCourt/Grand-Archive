namespace GrandArchive.Models.Configuration;

public interface IGrandArchiveSettings
{
    string DatabaseConnectionString { get; set; }
    string DndToolsConnectionString { get; set; }
}