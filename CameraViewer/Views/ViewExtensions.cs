using CameraViewer.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace CameraViewer.Views;

public static class ViewExtensions
{
    public static IServiceCollection AddViews(this IServiceCollection collection)
    {
        collection.AddSingleton<MainWindow>(service => new MainWindow
        {
            DataContext = service.GetRequiredService<MainWindowViewModel>()
        });
        
        collection.AddTransient<CameraEditingWindow>(service => new CameraEditingWindow
        {
            DataContext = service.GetRequiredService<CameraEditingWindowViewModel>()
        });
        
        collection.AddTransient<SettingWindow>(service => new SettingWindow
        {
            DataContext = service.GetRequiredService<SettingWindowViewModel>()
        });
        
        return collection;
    }
}
