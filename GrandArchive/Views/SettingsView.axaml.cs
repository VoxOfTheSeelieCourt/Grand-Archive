using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;

namespace GrandArchive.Views;

public partial class SettingsView : UserControl
{
    public SettingsView()
    {
        InitializeComponent();
    }

    private async void BrowseDatabasePathInput_OnClick(object sender, RoutedEventArgs e)
    {
        DatabasePathInput.Text = await SelectPath() ?? DatabasePathInput.Text;
    }

    private async void BrowseDndToolsPathInput_OnClick(object sender, RoutedEventArgs e)
    {
        DndToolsPathInput.Text = await SelectPath() ?? DndToolsPathInput.Text;
    }

    private async Task<string> SelectPath()
    {
        // Get top level from the current control. Alternatively, you can use Window reference instead.
        var topLevel = TopLevel.GetTopLevel(this);

        // Start async operation to open the dialog.
        var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "Open Database File",
            AllowMultiple = false,
            FileTypeFilter = [new FilePickerFileType("SQLite Database") {Patterns = ["*.sqlite"]}],
        });

        return files.FirstOrDefault()?.Path.AbsolutePath.Replace("%20", " ");
    }
}