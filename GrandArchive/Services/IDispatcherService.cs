using System;
using System.Threading.Tasks;
using Avalonia.Threading;

namespace GrandArchive.Services;

public interface IDispatcherService
{
    void RunOnMainThread(Action action, DispatcherPriority? priority = null);
    Task RunOnMainThreadAsync(Action action, DispatcherPriority? priority = null);
}