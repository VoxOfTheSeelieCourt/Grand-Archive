using System;
using System.Threading.Tasks;
using Avalonia.Threading;

namespace GrandArchive.Services;

public class DispatcherService : IDispatcherService
{
    public void RunOnMainThread(Action action, DispatcherPriority? priority = null)
    {
        var dispatcher = Dispatcher.UIThread;

        if (dispatcher.CheckAccess())
            action();
        else
            dispatcher.Invoke(action, priority ?? DispatcherPriority.Normal);
    }

    public T RunOnMainThread<T>(Func<T> function, DispatcherPriority? priority = null)
    {
        var dispatcher = Dispatcher.UIThread;

        if (dispatcher.CheckAccess())
            return function();
        else
            return dispatcher.Invoke(function, priority ?? DispatcherPriority.Normal);
    }

    public async Task RunOnMainThreadAsync(Action action, DispatcherPriority? priority = null)
    {
        var dispatcher = Dispatcher.UIThread;

        if (dispatcher.CheckAccess())
            action();
        else
            await dispatcher.InvokeAsync(action, priority ?? DispatcherPriority.Normal);
    }

    public async Task<T> RunOnMainThreadAsync<T>(Func<T> function, DispatcherPriority? priority = null)
    {
        var dispatcher = Dispatcher.UIThread;

        if (dispatcher.CheckAccess())
            return function();
        else
            return await dispatcher.InvokeAsync(function, priority ?? DispatcherPriority.Normal);
    }
}