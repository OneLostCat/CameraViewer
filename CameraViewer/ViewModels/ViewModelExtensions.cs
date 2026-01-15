using Microsoft.Extensions.DependencyInjection;

namespace CameraViewer.ViewModels;

public static class ViewModelExtensions
{
    public static void AddViewModels(this IServiceCollection collection)
    {
        collection.AddSingleton<MainWindowViewModel>();
        collection.AddTransient<CameraEditingWindowViewModel>();
        collection.AddTransient<SettingWindowViewModel>();
    }
}
