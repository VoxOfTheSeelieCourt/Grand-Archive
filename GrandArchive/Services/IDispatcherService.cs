using System;

namespace GrandArchive.Services;

public interface IDispatcherService
{
    void RunOnMainThread(Action action);
}