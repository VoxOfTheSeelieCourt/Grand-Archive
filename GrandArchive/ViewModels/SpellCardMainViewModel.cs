using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GrandArchive.Helpers.Attributes;
using GrandArchive.Models.Database;
using GrandArchive.Services.UserInformationService;
using GrandArchive.ViewModels.Abstract;
using Microsoft.EntityFrameworkCore;

namespace GrandArchive.ViewModels;

[NavigableMenuItem("Spell Cards", "LayerRegular")]
public partial class SpellCardMainViewModel : NavigableViewModel
{
    private readonly IDbContextFactory<DatabaseContext> _dbContextFactory;
    private readonly IUserInformationMessageService _userInformationMessageService;

    [ObservableProperty] private ObservableCollection<DndSpell> _spells;

    public List<DndRulebook> RuleBooks { get; set; }
    public List<DndClass> Classes { get; set; }

    public SpellCardMainViewModel(IDbContextFactory<DatabaseContext> dbContextFactory, IUserInformationMessageService userInformationMessageService)
    {
        _dbContextFactory = dbContextFactory;
        _userInformationMessageService = userInformationMessageService;

        LoadBaseData();
        Task.Run(LoadSpells);
    }

    private void LoadBaseData()
    {
        using var dbContext = _dbContextFactory.CreateDbContext();
        
        RuleBooks = dbContext.DndRulebooks.Include(x => x.DndEdition).ToList();
        Classes = dbContext.DndClasses.ToList();
    }

    [RelayCommand]
    private async Task LoadSpells()
    {
        try
        {
            await using var dbContext = await _dbContextFactory.CreateDbContextAsync();

            Spells = new ObservableCollection<DndSpell>(dbContext.DndSpells
                .Include(x => x.Rulebook).ThenInclude(x => x.DndEdition)
                .Include(x => x.ClassSpells).ThenInclude(x => x.Class)
                .ToList());
            
            foreach (var dndSpell in Spells)
            {
                if (dndSpell.CastingTime == "1 standard action")
                    dndSpell.CastingTime = "1 standard";
            }
        }
        catch (Exception e)
        {
            _userInformationMessageService.AddDisplayMessage("Error when loading spells", InformationType.Error, TimeSpan.FromMinutes(1), e.ToString());
        }
    }

    [RelayCommand]
    private async Task SaveSpells()
    {
        try
        {
            var updated = Spells.Where(x => x.HasChanges).ToList();

            if (updated.Count == 0)
            {
                _userInformationMessageService.AddDisplayMessage("No changes were made.", InformationType.Information, TimeSpan.FromSeconds(30));
                return;
            }
        
            updated.ForEach(x =>
            {
                x.UpdatedAt = DateTime.Now;
                x.HasChanges = false;
            });

            await using var dbContext = await _dbContextFactory.CreateDbContextAsync();
        
            dbContext.DndSpells.UpdateRange(updated);
        
            await dbContext.SaveChangesAsync();
            
            _userInformationMessageService.AddDisplayMessage($"Saved {updated.Count} spells.", InformationType.Success, TimeSpan.FromSeconds(30));
        }
        catch (Exception e)
        {
            _userInformationMessageService.AddDisplayMessage("Encountered an error during saving", InformationType.Error, TimeSpan.FromSeconds(30), e.Message);
        }
    }
}