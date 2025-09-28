using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GrandArchive.Helpers.Attributes;
using GrandArchive.Helpers.ExtensionMethods;
using GrandArchive.Models.Database;
using GrandArchive.Models.DnDTools;
using GrandArchive.Services.UserInformationService;
using GrandArchive.ViewModels.Abstract;
using Microsoft.EntityFrameworkCore;
using DndDomain = GrandArchive.Models.Database.DndDomain;
using DndRulebook = GrandArchive.Models.Database.DndRulebook;
using DndSpell = GrandArchive.Models.Database.DndSpell;
using DndSpellDescriptor = GrandArchive.Models.Database.DndSpellDescriptor;

namespace GrandArchive.ViewModels;

[NavigableMenuItem("Migration", "UpdateRegular")]
public partial class DnDDatabaseMigrationViewModel : NavigableViewModel
{
    private readonly IDbContextFactory<DndContext> _dndContextFactory;
    private readonly IDbContextFactory<DatabaseContext> _databaseContextFactory;
    private readonly IUserInformationMessageService _userInformationMessageService;

    [ObservableProperty] private int _value;
    [ObservableProperty] private int _maximum;

    public DnDDatabaseMigrationViewModel(IDbContextFactory<DndContext> dndContextFactory, IDbContextFactory<DatabaseContext> databaseContextFactory, IUserInformationMessageService userInformationMessageService)
    {
        _dndContextFactory = dndContextFactory;
        _databaseContextFactory = databaseContextFactory;
        _userInformationMessageService = userInformationMessageService;

        FixData();
    }

    // ReSharper disable once CognitiveComplexity
    private void FixData()
    {
        using var context = _dndContextFactory.CreateDbContext();

        context.DndSpells.First(x => x.Id == 3980).SubSchoolId = null;
        context.DndSpells.First(x => x.Id == 2987).Range = "Personal (see text)";
        context.DndSpells.First(x => x.Id == 754 || x.Id == 755 || x.Id == 3220 || x.Id == 2002).Range = "Touch";
        context.DndSpells.First(x => x.Id == 754).Target = "Animal or magical beast touched";
        context.DndSpells.First(x => x.Id == 755).Target = "Willing creature touched";
        context.DndSpells.First(x => x.Id == 2002).Target = "Living creature touched";
        context.DndSpelldescriptors1.First(x => x.Id == 24).Name = "Mind-Affecting and Chaotic";
        foreach (var d in context.DndSpellDescriptors.Where(x => x.SpelldescriptorId == 13))
            d.SpelldescriptorId = 26;
        foreach (var d in context.DndSpellDescriptors.Where(x => x.SpelldescriptorId == 36))
            d.SpelldescriptorId = 25;
        foreach (var d in context.DndSpellDescriptors.Where(x => x.SpelldescriptorId == 22 ||  x.SpelldescriptorId == 35 ||  x.SpelldescriptorId == 37 ||  x.SpelldescriptorId == 38 ||  x.SpelldescriptorId == 39 ||  x.SpelldescriptorId == 40 ||  x.SpelldescriptorId == 43 ||  x.SpelldescriptorId == 44))
            d.SpelldescriptorId = 23;
        foreach (var s in context.DndSpells.Where(x => x.Range == "Person"))
            s.Range = "Personal";
        foreach (var s in context.DndSpells.Where(x => x.Range.StartsWith("Close (")))
            s.Range = "Close";
        foreach (var s in context.DndSpells.Where(x => x.Range.StartsWith("Medium")))
            s.Range = "Medium";
        foreach (var s in context.DndSpells.Where(x => x.Range.StartsWith("Long (")))
            s.Range = "Long";
        foreach (var s in context.DndSpells.Where(x => x.Range.EndsWith("; see text")))
            s.Range = s.Range.Replace("; see text", " (see text)");
        foreach (var s in context.DndSpells.Where(x => x.Range.EndsWith(" ft")))
            s.Range += ".";

        context.SaveChanges();

        // var a = string.Join("\n", context.DndSpells.Where(x => x.XpComponent == 1).ToList().SelectMany(x =>
        // {
        //     var lines = x.Description.Split("\n");
        //     return lines.Where(l => l.Contains("XP")).ToList();
        // }).Distinct().OrderBy(x => x).ToList());
    }

    [RelayCommand]
    private void MigrateAll()
    {
        MigrateEditions();
        MigrateRulebooks();
        MigrateClasses();
        MigrateSpells();
        MigrateClassSpells();
    }

    [RelayCommand]
    private void MigrateEditions()
    {
        Task.Run(() => MigrateTable(x => x.DndDndeditions
                .OrderBy(y => y.System)
                .ThenByDescending(y => y.Core)
                .ToList(),
            (x, _) => new DndEdition()
            {
                CreatedAt = DateTime.Now,
                MigrationId = x.Id,
                Name = x.Name,
                System = x.System
            },
            x => x.DndEditions));
    }

    [RelayCommand]
    private void MigrateRulebooks()
    {
        Task.Run(() => MigrateTable(x => x.DndRulebooks.ToList(),
            (x, db) =>
            {
                var edition = db.DndEditions.First(y => y.MigrationId == x.DndEditionId);

                return new DndRulebook()
                {
                    CreatedAt = DateTime.Now,
                    MigrationId = x.Id,
                    Name = x.Name,
                    Abbreviation = x.Abbr,
                    Description = x.Description,
                    DndEdition = edition,
                    PublishingDay = x.Published?.Day,
                    PublishingMonth = x.Published?.Month,
                    PublishingYear = x.Published?.Year ?? (int.TryParse(x.Year, out var year) ? year : null),
                };
            },
            x => x.DndRulebooks));
    }

    [RelayCommand]
    private void MigrateClasses()
    {
        Task.Run(() => MigrateTable(x => x.DndCharacterclasses.ToList(),
            (x, _) => new DndClass()
            {
                CreatedAt = DateTime.Now,
                MigrationId = x.Id,
                Name = x.Name,
                IsPrestige = x.Prestige == 1,
            },
            x => x.DndClasses));
    }

    [RelayCommand]
    private void MigrateDomains()
    {
        Task.Run(() => MigrateTable(x => x.DndDomains.ToList(),
            (x, _) => new DndDomain()
            {
                CreatedAt = DateTime.Now,
                MigrationId = x.Id,
                Name = x.Name
            },
            x => x.DndDomains));
    }

    [RelayCommand]
    private void MigrateSpells()
    {
        Task.Run(() => MigrateTable(x => x.DndSpells
                .Include(y => y.School)
                .Include(y => y.SubSchool)
                .Include(y => y.Rulebook)
                .Include(y => y.DndSpellDescriptors).ThenInclude(y => y.Spelldescriptor)
                .Include(y => y.DndSpellclasslevels).ThenInclude(y => y.CharacterClass)
                .Where(y => y.SchoolId < 17)
                .ToList(),
            (x, db) =>
            {
                var rulebook = db.DndRulebooks.First(y => y.MigrationId == x.RulebookId);

                var school = x.School
                    .Name
                    .Split('/')
                    .Select(y => Enum.TryParse(typeof(DndSpellSchool), y, true, out var r)
                                 && r is DndSpellSchool dndSpellSchool
                        ? dndSpellSchool
                        : throw new ArgumentOutOfRangeException())
                    .Aggregate((z, y) => z | y);

                var subschool = x.SubSchool == null ? DndSpellSubSchool.None : x.SubSchool
                    .Name
                    .Split(' ')
                    .Where(y => y != "and" && y != "or")
                    .Select(y => Enum.TryParse(typeof(DndSpellSubSchool), y, true, out var r)
                                 && r is DndSpellSubSchool dndSpellSubSchool
                        ? dndSpellSubSchool
                        : throw new ArgumentOutOfRangeException())
                    .Aggregate((z, y) => z | y);

                var descriptor = x.DndSpellDescriptors.Count == 0
                    ? DndSpellDescriptor.None
                    : x.DndSpellDescriptors.SelectMany(y => y.Spelldescriptor
                        .Name
                        .Replace("see text", "Various")
                        .Split(' ')
                        .Where(z => z != "and" && z != "or")
                        .Select(z => Enum.TryParse(typeof(DndSpellDescriptor), z.Replace("-", ""), true, out var r)
                                     && r is DndSpellDescriptor dndSpellDescriptor
                            ? dndSpellDescriptor
                            : throw new ArgumentOutOfRangeException()))
                        .Aggregate((z, y) => z | y);

                var range = Enum.TryParse(typeof(DndSpellRange), x.Range, true, out var result)
                                 && result is DndSpellRange s
                        ? s
                        : DndSpellRange.Custom;

                var material = x.MaterialComponent == 0 ? "" : Regex.Match(x.Description, @"[Mm]aterial [Cc]omponents?[_*]?[:\.][_*]? ?([^\n]+)").Groups[1].Value;
                var xp = x.XpComponent == 0 ? "" : Regex.Match(x.Description, @"XP [Cc]ost_?:_? ?([^\n]+)").Groups[1].Value;
                var corruption = x.CorruptComponent == 0 ? "" : Regex.Match(x.Description, @"[Cc]orruption [Cc]ost_?:_? ?([^\n]+)").Groups[1].Value;

                return new DndSpell
                {
                    CreatedAt = DateTime.Now,
                    MigrationId = x.Id,
                    Name = x.Name,
                    Rulebook = rulebook,
                    RulebookPage = x.Page,
                    School = school,
                    SubSchool = subschool,
                    Descriptor = descriptor,
                    HasVerbalComponent = x.VerbalComponent == 1,
                    HasSomaticComponent = x.SomaticComponent == 1,
                    HasMaterialComponent = x.MaterialComponent == 1,
                    MaterialComponent = material,
                    HasArcaneFocus = x.ArcaneFocusComponent == 1,
                    HasDivineFocus = x.DivineFocusComponent == 1,
                    HasExperienceComponent = x.XpComponent == 1,
                    ExperienceComponent = xp,
                    HasBreathComponent = x.MetaBreathComponent == 1,
                    HasTruenameComponent = x.TrueNameComponent == 1,
                    HasCorruptionComponent = x.CorruptComponent == 1,
                    CorruptionComponent = corruption,
                    ExtraComponent = x.ExtraComponents ?? "",
                    CastingTime = x.CastingTime ?? "",
                    Range = range,
                    CustomRangeText = (range.HasFlag(DndSpellRange.Custom) || range.GetFlags().Count() > 1 ? x.Range : "") ?? "",
                    Target = x.Target ?? "",
                    Effect = x.Effect ?? "",
                    Area = x.Area ?? "",
                    Duration = x.Duration ?? "",
                    SavingThrow = x.SavingThrow ?? "",
                    SpellResistance = x.SpellResistance ?? "No",
                    Description = x.Description,
                    DescriptionShort = "",
                    AbstinenceComponent = "",
                    ArcaneFocus = "",
                    ColdfireComponent = "",
                    DiseaseComponent = "",
                    DragonmarkComponent = "",
                    DrugComponent = "",
                    LocationComponent = "",
                    MindsetComponent = "",
                    SacrificeComponent = "",
                    TruenameComponent = ""
                };
            },
            x => x.DndSpells));
    }

    [RelayCommand]
    private void MigrateClassSpells()
    {
        Task.Run(() => MigrateTable(x => x.DndSpellclasslevels
                .Include(y => y.Spell)
                .Include(y => y.CharacterClass)
                .Where(y => y.Spell.SchoolId < 17)
                .ToList(),
            (x, db) =>
            {
                var spell = db.DndSpells.First(y => y.MigrationId == x.SpellId);
                var cls = db.DndClasses.First(y => y.MigrationId == x.CharacterClassId);

                return new DndClassSpell()
                {
                    CreatedAt = DateTime.Now,
                    MigrationId = x.Id,
                    Class = cls,
                    Spell = spell,
                    Level = x.Level,
                };
            },
            x => x.DndClassSpells));
    }

    [RelayCommand]
    private void MigrateDomainSpells()
    {
        Task.Run(() => MigrateTable(x => x.DndSpelldomainlevels
                .Include(y => y.Spell)
                .Include(y => y.Domain)
                .Where(y => y.Spell.SchoolId < 17)
                .ToList(),
            (x, db) =>
            {
                var spell = db.DndSpells.First(y => y.MigrationId == x.SpellId);
                var domain = db.DndDomains.First(y => y.MigrationId == x.DomainId);

                return new DndDomainSpell()
                {
                    CreatedAt = DateTime.Now,
                    MigrationId = x.Id,
                    Domain = domain,
                    Spell = spell,
                    Level = x.Level,
                };
            },
            x => x.DndDomainSpells));
    }

    /// <summary>
    /// Migrates a database table in the new database by fetching data from the old database with <paramref name="sourceData"/>, converting it with <paramref name="convert"/> and writing it to <paramref name="set"/> after clearing all items with a set <see cref="DatabaseObject.MigrationId"/>.
    /// </summary>
    private async Task MigrateTable<TSource, TTarget>(
        Func<DndContext, List<TSource>> sourceData,
        Func<TSource, DatabaseContext, TTarget> convert,
        Func<DatabaseContext, DbSet<TTarget>> set) where TTarget : DatabaseObject
    {
        try
        {
            await using var oldModel = await _dndContextFactory.CreateDbContextAsync();
            await using var newModel = await _databaseContextFactory.CreateDbContextAsync();

            var old = sourceData(oldModel);
            Maximum = old.Count;
            Value = 0;

            var newData = new List<TTarget>();
            foreach (var source in old)
            {
                newData.Add(convert(source, newModel));
                Value++;
            }

            set(newModel).RemoveRange(set(newModel).Where(x => x.MigrationId.HasValue));
            await set(newModel).AddRangeAsync(newData);

            await newModel.SaveChangesAsync();

            _userInformationMessageService.AddDisplayMessage($"Added {newData.Count} items", InformationType.Success, TimeSpan.FromSeconds(30));
        }
        catch (Exception e)
        {
            _userInformationMessageService.AddDisplayMessage("Encountered an error", InformationType.Error, TimeSpan.FromSeconds(30), e.ToString());
        }
    }
}