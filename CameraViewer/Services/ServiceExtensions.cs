using LibVLCSharp.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace CameraViewer.Services;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection collection)
    {
        collection.AddSingleton<LibVLC>(_ => new LibVLC("--reset-plugins-cache"));

        collection.AddSingleton<MediaPlayer>(service => new MediaPlayer(service.GetRequiredService<LibVLC>())
            { EnableHardwareDecoding = true });

        collection.AddSingleton<StorageService>();
        
        return collection;
    }
}
