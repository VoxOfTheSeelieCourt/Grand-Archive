using Avalonia.Controls;

namespace GrandArchive.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void SelectingItemsControl_OnSelectionChanged(object sender, SelectionChangedEventArgs selectionChangedEventArgs)
    {
        MenuToggleButton.IsChecked = false;
    }
}