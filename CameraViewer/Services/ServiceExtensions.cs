using CameraViewer.ViewModels;
using CameraViewer.Views;
using LibVLCSharp.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace CameraViewer.Services;

public static class ServiceExtensions
{
    public static ServiceProvider BuildService()
    {
        var collection = new ServiceCollection();

        // View
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
        
        // ViewModel
        collection.AddSingleton<MainWindowViewModel>();
        collection.AddTransient<CameraEditingWindowViewModel>();
        collection.AddTransient<SettingWindowViewModel>();

        // 服务
        collection.AddSingleton<LibVLC>(_ => new LibVLC("--reset-plugins-cache"));
        collection.AddSingleton<MediaPlayer>(service => new MediaPlayer(service.GetRequiredService<LibVLC>())
            { EnableHardwareDecoding = true });

        return collection.BuildServiceProvider();
    }
}
