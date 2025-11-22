using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data;
using Avalonia.Data.Core.Plugins;
using Avalonia.LogicalTree;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.MarkupExtensions;
using GrandArchive.Helpers;
using GrandArchive.Helpers.ExtensionMethods;
using GrandArchive.Models.Database;
using GrandArchive.Models.DnDTools;
using GrandArchive.Services.UserInformationService;
using GrandArchive.ViewModels;
using GrandArchive.Views;
using Microsoft.Extensions.DependencyInjection;

namespace GrandArchive;

// ReSharper disable once PartialTypeWithSinglePart
public partial class App : Application
{
    public static IUserInformationMessageService UserInformationMessageService { get; private set; }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        // Avoid duplicate validations from both Avalonia and the CommunityToolkit.
        // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
        // DisableAvaloniaDataAnnotationValidation();

        var collection = new ServiceCollection();
        collection.Configure();

        var services = collection.BuildServiceProvider();

        services.InitDatabase<DndContext>()
            .InitDatabase<DatabaseContext>();

        var vm = services.GetRequiredService<MainWindowViewModel>();

        switch (ApplicationLifetime)
        {
            case IClassicDesktopStyleApplicationLifetime desktop:
                desktop.MainWindow = new MainWindow {DataContext = vm};
                break;
        }

        UserInformationMessageService = services.GetRequiredService<IUserInformationMessageService>();

        base.OnFrameworkInitializationCompleted();
    }

    // ReSharper disable once UnusedMember.Local
    private static void DisableAvaloniaDataAnnotationValidation()
    {
        // Get an array of plugins to remove
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        // remove each entry found
        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }

    private void TextBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        if (sender is not ILogical logical)
            return;

        var header = logical.FindLogicalAncestorOfType<DataGridColumnHeader>();
        var dataGrid = header?.FindLogicalAncestorOfType<DataGrid>();

        if (header == null || dataGrid == null)
            return;

        var column = dataGrid.Columns.SingleOrDefault(x => x.Header == header.Content);

        DataGridFilterBehavior.SetFilterText(column, (sender as TextBox).Text);
    }
}