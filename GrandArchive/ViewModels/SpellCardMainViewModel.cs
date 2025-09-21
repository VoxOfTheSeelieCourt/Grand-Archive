using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GrandArchive.Helpers.Attributes;
using GrandArchive.Models;
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

    public SpellCardMainViewModel(IDbContextFactory<DatabaseContext> dbContextFactory, IUserInformationMessageService userInformationMessageService)
    {
        _dbContextFactory = dbContextFactory;
        _userInformationMessageService = userInformationMessageService;

        Task.Run(LoadSpells);
    }

    [RelayCommand]
    private async Task LoadSpells()
    {
        await using var dbContext = await _dbContextFactory.CreateDbContextAsync();

        Spells = new ObservableCollection<DndSpell>(dbContext.DndSpells.Include(x => x.Rulebook).ToList());
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
        
            updated.ForEach(x => x.UpdatedAt = DateTime.Now);

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

    [RelayCommand]
    private async Task ExportSpellCards()
    {
        throw new NotImplementedException();
    }
}