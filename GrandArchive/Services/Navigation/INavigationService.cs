using System.ComponentModel;
using System.Threading.Tasks;
using GrandArchive.ViewModels.Abstract;

namespace GrandArchive.Services.Navigation;

public interface INavigationService : INotifyPropertyChanged
{
    public NavigableViewModel ActiveViewModel { get; }
    public bool CanGoBack { get; }
    public bool CanGoForward { get; }

    public bool Navigate(NavigableViewModel target);
    public Task<bool> NavigateAsync(NavigableViewModel target);
    public void GoBack();
    public bool TryGoBack();
    public Task GoBackAsync();
    public Task<bool> TryGoBackAsync();
    public void GoForward();
    public bool TryGoForward();
    public Task GoForwardAsync();
    public Task<bool> TryGoForwardAsync();
}