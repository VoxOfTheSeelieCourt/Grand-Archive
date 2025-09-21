using System;
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace GrandArchive.Models.Database;

public abstract partial class DatabaseObject : ObservableObject
{
    [ObservableProperty] [property: Key] private int _id;
    [ObservableProperty] private int? _migrationId;
    [ObservableProperty] private DateTime _createdAt;
    [ObservableProperty] private DateTime? _updatedAt;
}