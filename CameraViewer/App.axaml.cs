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
using Microsoft.Extensions.Hosting;
using Serilog;

namespace CameraViewer;

public class App : Application
{
    public new static App Current => Application.Current as App ?? throw new Exception("无法获取 App");
    public IHost AppHost { get; private set; } = null!;

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
        
        // 主机
        var builder = Host.CreateEmptyApplicationBuilder(new HostApplicationBuilderSettings());

        // 日志
        builder.Services.AddSerilog(logger => logger
            .WriteTo.Console()
            .WriteTo.File("log/main-.txt",rollingInterval: RollingInterval.Day)
            .Enrich.FromLogContext()
        );

        // 服务
        builder.Services.AddServices();
        builder.Services.AddViews();
        builder.Services.AddViewModels();

        AppHost = builder.Build();
        AppHost.Start();
    }

    public override void OnFrameworkInitializationCompleted()
    {
        // 禁用 Avalonia 自带的数据验证，以避免与 CommunityToolkit 的验证冲突
        // 参考 https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
        DisableAvaloniaDataValidation();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = AppHost.Services.GetRequiredService<MainWindow>();
            desktop.Exit += (_, _) => AppHost.Dispose();
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
