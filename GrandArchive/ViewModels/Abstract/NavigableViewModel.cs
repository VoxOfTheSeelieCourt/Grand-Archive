namespace GrandArchive.ViewModels.Abstract;

public abstract class NavigableViewModel : ViewModelBase
{
    /// <summary>
    /// The title of the view model that is automatically displayed in the UI. If the view model itself defines no title, "NOT LOCALIZED" serves both as a fallback and a reminder.
    /// </summary>
    public virtual string ViewModelTitle { get; } = "NOT LOCALIZED";

    public virtual void OnNavigateTo() { }

    /// <summary>
    /// A method that is called when the navigation service navigates to another view model or when the application is closing.
    /// </summary>
    /// <returns>True if the navigation is allowed (e.g. the executing view has no unsaved changes)</returns>
    public virtual bool OnNavigateFrom() { return true; }
}