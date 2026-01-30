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

    private async void BtnDatabase_OnClick(object sender, RoutedEventArgs e)
    {
        txtDatabase.Text = await SelectPath() ?? txtDatabase.Text;
    }

    private async void BtnDndTools_OnClick(object sender, RoutedEventArgs e)
    {
        txtDndTools.Text = await SelectPath() ?? txtDndTools.Text;
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