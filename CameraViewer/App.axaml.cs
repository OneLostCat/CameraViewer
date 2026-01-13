using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using System.Linq;
using Avalonia.Markup.Xaml;
using CameraViewer.Services;
using CameraViewer.ViewModels;
using CameraViewer.Views;
using Microsoft.Extensions.DependencyInjection;

namespace CameraViewer;

public partial class App : Application
{
    public new static App Current => Application.Current as App ?? throw new Exception("无法初始化 Current");
    public ServiceProvider Service { get; } = ServiceExtensions.BuildService();

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        // 禁用 Avalonia 自带的数据验证，以避免与 CommunityToolkit 的验证冲突
        // 参考 https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
        DisableAvaloniaDataValidation();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = Service.GetRequiredService<MainWindow>();
            desktop.Exit += (_, _) => Service.Dispose();
        }

        base.OnFrameworkInitializationCompleted();
    }

    private static void DisableAvaloniaDataValidation()
    {
        // Get an array of plugins to remove
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        // remove each entry found
        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }
}
