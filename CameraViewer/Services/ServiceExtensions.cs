using CameraViewer.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace CameraViewer.Services;

public static class ServiceExtensions
{
    public static ServiceProvider BuildService()
    {
        var collection = new ServiceCollection();
        
        collection.AddSingleton<MainWindowViewModel>();
        
        return collection.BuildServiceProvider();
    }
}
