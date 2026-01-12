using System;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using CameraViewer.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LibVLCSharp.Shared;

namespace CameraViewer.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly LibVLC _libVlc = new();

    [ObservableProperty] private MediaPlayer _mediaPlayer;

    [ObservableProperty] private int _volume = 100;

    [ObservableProperty] private float _rate = 1;
    
    [ObservableProperty] private double _rateStep = 2; // 1x 速率

    public MainWindowViewModel()
    {
        MediaPlayer = new MediaPlayer(_libVlc);
    }

    [RelayCommand]
    private void Switch()
    {
        if (Design.IsDesignMode) return;

        if (MediaPlayer.IsPlaying)
        {
            MediaPlayer.Pause();
        }
        else if (MediaPlayer.Media != null)
        {
            MediaPlayer.Play();
        }
        else
        {
            using var media = new Media(_libVlc,
                new Uri("http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4"));

            MediaPlayer.Play(media);
        }
    }

    [RelayCommand]
    private void MoveForward() => 
        MediaPlayer.Time += 5 * 1000;

    [RelayCommand]
    private void MoveBackward() => 
        MediaPlayer.Time -= 5 * 1000;
    
    [RelayCommand]
    private void JumpForward() => 
        MediaPlayer.Time += 60 * 1000;

    [RelayCommand]
    private void JumpBackward() => 
        MediaPlayer.Time -= 60 * 1000;

    partial void OnVolumeChanged(int value) => 
        MediaPlayer.Volume = value;

    partial void OnRateStepChanged(double value)
    {
        float[] rateSteps = [0.25f, 0.5f, 1, 2, 4, 8, 16];
        
        var rate = rateSteps[(int)value];
        
        MediaPlayer.SetRate(rate);
        Rate = rate;
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
