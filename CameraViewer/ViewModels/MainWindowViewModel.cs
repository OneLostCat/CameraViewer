using System;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using CameraViewer.Models;
using LibVLCSharp.Shared;

namespace CameraViewer.ViewModels;

public partial class MainWindowViewModel : ViewModelBase, IDisposable
{
    private readonly LibVLC _libVlc = new();

    public MediaPlayer MediaPlayer { get; }

    public MainWindowViewModel()
    {
        MediaPlayer = new MediaPlayer(_libVlc);
    }
    
    private void Switch()
    {
        if (MediaPlayer.IsPlaying)
        {
            Pause();
        }
        else
        {
            Play();
        }
    }

    public void Play()
    {
        if (Design.IsDesignMode) return;
        
        using var media = new Media(_libVlc,
            new Uri("http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4"));
        
        MediaPlayer.Play(media);
    }

    public void Pause()
    {
        MediaPlayer.Pause();
    }
    
    public void Stop()
    {
        MediaPlayer.Stop();
    }

    public void Dispose()
    {
        MediaPlayer.Dispose();
        _libVlc.Dispose();

        GC.SuppressFinalize(this);
    }

    public ObservableCollection<Camera> Cameras { get; } =
    [
        new() { Name = "摄像机 1" },
        new() { Name = "摄像机 2" },
        new() { Name = "摄像机 3" },
        new() { Name = "摄像机 4" },
        new() { Name = "摄像机 5" },
        new() { Name = "摄像机 6" },
        new() { Name = "摄像机 7" },
        new() { Name = "摄像机 8" },
    ];

    public ObservableCollection<Event> Events { get; } =
    [
        new()
        {
            Title = "事件 1", ImageUrl = "https://cn.bing.com/th?id=OHR.MatterhornSunrise_EN-US9978097106_UHD.jpg&pid=hp&w=1920"
        },
        new()
        {
            Title = "事件 2", ImageUrl = "https://cn.bing.com/th?id=OHR.MatterhornSunrise_EN-US9978097106_UHD.jpg&pid=hp&w=1920"
        },
        new()
        {
            Title = "事件 3", ImageUrl = "https://cn.bing.com/th?id=OHR.MatterhornSunrise_EN-US9978097106_UHD.jpg&pid=hp&w=1920"
        },
        new()
        {
            Title = "事件 4", ImageUrl = "https://cn.bing.com/th?id=OHR.MatterhornSunrise_EN-US9978097106_UHD.jpg&pid=hp&w=1920"
        },
        new()
        {
            Title = "事件 5", ImageUrl = "https://cn.bing.com/th?id=OHR.MatterhornSunrise_EN-US9978097106_UHD.jpg&pid=hp&w=1920"
        },
        new()
        {
            Title = "事件 6", ImageUrl = "https://cn.bing.com/th?id=OHR.MatterhornSunrise_EN-US9978097106_UHD.jpg&pid=hp&w=1920"
        },
        new()
        {
            Title = "事件 7", ImageUrl = "https://cn.bing.com/th?id=OHR.MatterhornSunrise_EN-US9978097106_UHD.jpg&pid=hp&w=1920"
        },
        new()
        {
            Title = "事件 8", ImageUrl = "https://cn.bing.com/th?id=OHR.MatterhornSunrise_EN-US9978097106_UHD.jpg&pid=hp&w=1920"
        },
    ];
}
