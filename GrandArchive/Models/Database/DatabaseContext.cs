using System.IO;
using GrandArchive.Helpers;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace GrandArchive.Models.Database;

/// <remarks>
/// Add migration: dotnet ef migrations add REPLACEME --context DatabaseContext --project GrandArchive
/// Update database: dotnet ef database update --context DatabaseContext --project GrandArchive
/// </remarks>
public class DatabaseContext : DbContext
{
    #region Configuration

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var path = Path.Combine(DataLocationHelper.GetRootFolder(), "Database.sqlite");

        var connectionStringBuilder = new SqliteConnectionStringBuilder
        {
            DataSource = path,
            Mode = SqliteOpenMode.ReadWriteCreate,
            // Cache = SqliteCacheMode.Shared,
        };
        
        optionsBuilder.UseSqlite(connectionStringBuilder.ConnectionString);
    }

    #endregion
    
    #region Tables
    
    public DbSet<DndEdition> DndEditions { get; set; }
    public DbSet<DndRulebook> DndRulebooks { get; set; }
    public DbSet<DndSpell> DndSpells { get; set; }
    
    #endregion
}