using Avalonia.Controls;
using GrandArchive.ViewModels;

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

    private void Window_OnClosing(object sender, WindowClosingEventArgs e)
    {
        if (DataContext is not MainWindowViewModel vm || vm.ActiveViewModel == null)
            return;

        if (!vm.ActiveViewModel.OnNavigateFrom())
            e.Cancel = true;
    }
}