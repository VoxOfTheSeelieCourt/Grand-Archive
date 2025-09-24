using System;
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace GrandArchive.Models.Database;

public abstract partial class DatabaseObject : ObservableObject
{
#pragma warning disable CS0657 // Not a valid attribute location for this declaration
    [ObservableProperty] [property: Key] private int _id;
#pragma warning restore CS0657 // Not a valid attribute location for this declaration
    [ObservableProperty] private int? _migrationId;
    [ObservableProperty] private DateTime _createdAt;
    [ObservableProperty] private DateTime? _updatedAt;

    public override bool Equals(object obj)
    {
        return obj is DndRulebook rulebook && rulebook.Id == Id;
    }
}