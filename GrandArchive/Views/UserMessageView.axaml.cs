using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.VisualTree;

namespace GrandArchive.Views;

public partial class UserMessageView : UserControl
{
    public UserMessageView()
    {
        InitializeComponent();
    }

    private void Button_OnClick(object sender, RoutedEventArgs e)
    {
        var root = ErrorDetailBlock.GetVisualRoot();
        if (root is not TopLevel topLevel
            || topLevel.Clipboard == null)
            return;

        topLevel.Clipboard.SetTextAsync(ErrorDetailBlock.Text);
    }
}