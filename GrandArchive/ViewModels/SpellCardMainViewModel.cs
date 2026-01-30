using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AvaloniaDialogs.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GrandArchive.Helpers.Attributes;
using GrandArchive.Helpers.ExtensionMethods;
using GrandArchive.Models.Database;
using GrandArchive.Services;
using GrandArchive.Services.UserInformationService;
using GrandArchive.ViewModels.Abstract;
using Microsoft.EntityFrameworkCore;

namespace GrandArchive.ViewModels;

[NavigableMenuItem("Spell Cards", "LayerRegular")]
public partial class SpellCardMainViewModel : NavigableViewModel
{
    private readonly DatabaseContext _dbContext;
    private readonly IDispatcherService _dispatcherService;
    private readonly IUserInformationMessageService _userInformationMessageService;

    [ObservableProperty] private ObservableCollection<DndSpell> _spells;

    public List<DndRulebook> RuleBooks { get; set; }
    public List<DndClass> Classes { get; set; }

    public int VerifiedSpellsCount => Spells?.Count(x => x.IsVerified) ?? 0;

    public SpellCardMainViewModel(DatabaseContext dbContext, IUserInformationMessageService userInformationMessageService, IDispatcherService dispatcherService)
    {
        _dbContext = dbContext;
        _dispatcherService = dispatcherService;
        _userInformationMessageService = userInformationMessageService;

        LoadBaseData();
        Task.Run(LoadSpells);
    }

    /// <inheritdoc/>
    public override bool OnNavigateFrom()
    {
        return MayOverrideUnsavedChanges().GetAwaiter().GetResult();
    }

    private async Task<bool> MayOverrideUnsavedChanges()
    {
        if (Spells?.Any(x => x.HasChanges) != true)
            return true;

        var tsk = _dispatcherService.RunOnMainThread(() =>
        {
            var dialog = new ThreefoldDialog()
            {
                Message = "There are unsaved changes that will be overridden. Do you want to save before you continue?",
                PositiveText = "Save",
                NeutralText = "Cancel",
                NegativeText = "Discard"
            };
            return dialog.ShowAsync();
        });
        var result = await tsk;

        if (!result.HasValue)
            return false;

        switch (result.Value)
        {
            case ThreefoldDialog.ButtonType.Negative:
                return true;
            case ThreefoldDialog.ButtonType.Positive:
                await SaveSpells();
                return true;
            case ThreefoldDialog.ButtonType.Neutral:
                return false;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    partial void OnSpellsChanged(ObservableCollection<DndSpell> value)
    {
        Spells.CollectionChanged += (_, args) =>
        {
            if (args.NewItems == null)
                return;

            var items = args.NewItems.Cast<DndSpell>().ToList();
            AddSpellPropertyChangedHandler(items);
        };
        AddSpellPropertyChangedHandler(Spells.ToList());
    }

    private void AddSpellPropertyChangedHandler(List<DndSpell> spells)
    {
        foreach (var dndSpell in spells)
        {
            dndSpell.PropertyChanged += (_, eventArgs) =>
            {
                if (eventArgs.PropertyName == nameof(DndSpell.IsVerified))
                    UpdateCountVerified();
            };
        }
    }

    private void LoadBaseData()
    {
        RuleBooks = _dbContext.DndRulebooks.Include(x => x.DndEdition).AsNoTracking().ToList();
        Classes = _dbContext.DndClasses.AsNoTracking().ToList();
    }

    private void UpdateCountVerified()
    {
        OnPropertyChanged(nameof(VerifiedSpellsCount));
    }

    [RelayCommand]
    private async Task LoadSpells()
    {
        if (!await MayOverrideUnsavedChanges())
            return;

        try
        {
            Spells = new ObservableCollection<DndSpell>(_dbContext.DndSpells
                .Include(x => x.Rulebook).ThenInclude(x => x.DndEdition)
                .Include(x => x.ClassSpells).ThenInclude(x => x.Class)
                .Include(x => x.DomainSpells).ThenInclude(x => x.Domain)
                .Include(x => x.VariantOfSpell)
                .Where(x => x.Rulebook.Id == _dbContext.DndSpells.Where(y => !y.IsVerified && y.Rulebook.DndEdition.Id == 8).GroupBy(y => y.Rulebook.Id).OrderBy(y => y.Count()).First().Key)
                // .Where(x => x.Rulebook.Id == dbContext.DndSpells.Where(y => !y.IsVerified && y.Rulebook.DndEdition.System == "DnD 3.5").GroupBy(y => y.Rulebook.Id).OrderBy(y => y.Count()).First().Key)
                // .Where(x => x.Rulebook.Id == 3)
                // .Where(x => x.Rulebook.DndEdition.System == "DnD 3.5")
                // .Where(x => !x.IsVerified)
                // .Where(x => x.Description.Contains("spells/"))
                .AsNoTracking()
                .ToList());

            AutoFormatSpells();

            UpdateCountVerified();
        }
        catch (Exception e)
        {
            _userInformationMessageService.AddDisplayMessage("Error when loading spells", InformationType.Error, TimeSpan.FromMinutes(1), e.ToString());
        }
    }

    private void AutoFormatSpells()
    {
        // Add database wide formatting here if needed

        // foreach (var dndSpell in Spells)
        // {
        //     var match = FlavorTextRegex().Match(dndSpell.Description);
        //     if (!match.Success)
        //         continue;
        //
        //     dndSpell.FlavorText = match.Groups[1].Value;
        //     dndSpell.Description = FlavorTextRegex().Replace(dndSpell.Description, "").Trim(' ', '\r', '\n', '\t');
        // }
    }

    [RelayCommand]
    private async Task SaveSpells()
    {
        try
        {
            var updated = Spells.Where(x => x.HasChanges).ToList();

            if (updated.Count == 0)
            {
                _userInformationMessageService.AddDisplayMessage("No changes were made.", InformationType.Information, TimeSpan.FromSeconds(1));
                return;
            }

            updated.ForEach(x =>
            {
                x.UpdatedAt = DateTime.Now;
            });

            _dbContext.UpdateRangeWithNavigations(updated);

            await _dbContext.SaveChangesAsync();

            updated.ForEach(x =>
            {
                x.HasChanges = false;
            });

            _userInformationMessageService.AddDisplayMessage($"Saved {updated.Count} spells.", InformationType.Success, TimeSpan.FromSeconds(1));
        }
        catch (Exception e)
        {
            _userInformationMessageService.AddDisplayMessage("Encountered an error during saving", InformationType.Error, TimeSpan.FromSeconds(30), e.Message);
        }
    }
}