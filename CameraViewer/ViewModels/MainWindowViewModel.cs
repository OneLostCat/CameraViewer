using System;
using System.Collections.ObjectModel;
using System.Globalization;
using Avalonia.Controls;
using CameraViewer.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LibVLCSharp.Shared;

namespace CameraViewer.ViewModels;

public partial class MainWindowViewModel : ViewModelBase, IDisposable
{
    private readonly LibVLC _libVlc;
    private readonly Media _media;

    // 播放器
    [ObservableProperty] private MediaPlayer _mediaPlayer;
    [ObservableProperty] private int _volume = 100;
    [ObservableProperty] private float _rate = 1;
    [ObservableProperty] private double _rateStep = 2; // 1x 速率

    // 时间
    private bool _timeChanging;
    private DateTime _time = DateTime.Now;
    private DateTime _playbackTime;

    [ObservableProperty] private string _year = "";
    [ObservableProperty] private string _month = "";
    [ObservableProperty] private string _day = "";
    [ObservableProperty] private string _hour = "";
    [ObservableProperty] private string _minute = "";
    [ObservableProperty] private string _second = "";

    public MainWindowViewModel()
    {
        Core.Initialize();
        
        _libVlc = new LibVLC();
        _media = new Media(_libVlc, new Uri(@"C:\Users\OneLo\Desktop\00_20260113032111_20260113040202.mp4"));

        MediaPlayer = new MediaPlayer(_libVlc);
        MediaPlayer.EnableHardwareDecoding = true;
        MediaPlayer.TimeChanged += OnTimeChanged;
    }

    public void Dispose()
    {
        _libVlc.Dispose();
        _media.Dispose();
        MediaPlayer.Dispose();

        GC.SuppressFinalize(this);
    }

    // 控件
    [RelayCommand]
    private void Switch()
    {
        if (Design.IsDesignMode) return;

        switch (MediaPlayer.State)
        {
            case VLCState.Playing:
                MediaPlayer.Pause();
                break;
            case VLCState.Paused:
                MediaPlayer.Play();
                break;
            default:
                MediaPlayer.Play(_media);
                MediaPlayer.Position = 0; // 修复无法加载视频的神奇 Bug
                break;
        }
    }

    [RelayCommand]
    private void MoveForward()
    {
        MediaPlayer.Time = Math.Min(MediaPlayer.Time + 5_000, MediaPlayer.Length);
    }

    [RelayCommand]
    private void JumpForward()
    {
        MediaPlayer.Time = Math.Min(MediaPlayer.Time + 60_000, MediaPlayer.Length);
    }

    [RelayCommand]
    private void MoveBackward()
    {
        MediaPlayer.Time = Math.Max(MediaPlayer.Time - 5_000, 0);
    }

    [RelayCommand]
    private void JumpBackward()
    {
        MediaPlayer.Time = Math.Max(MediaPlayer.Time - 60_000, 0);
    }
    
    partial void OnVolumeChanged(int value)
    {
        MediaPlayer.Volume = value;
    }

    partial void OnRateStepChanged(double value)
    {
        float[] rateSteps = [0.25f, 0.5f, 1, 2, 4, 8, 16];

        var rate = rateSteps[(int)value];

        MediaPlayer.SetRate(rate);
        Rate = rate;
    }
    
    partial void OnYearChanged(string value) => OnTimeChanged();
    partial void OnMonthChanged(string value) => OnTimeChanged();
    partial void OnDayChanged(string value) => OnTimeChanged();
    partial void OnHourChanged(string value) => OnTimeChanged();
    partial void OnMinuteChanged(string value) => OnTimeChanged();
    partial void OnSecondChanged(string value) => OnTimeChanged();

    private void OnTimeChanged()
    {
        _timeChanging = true;

        var success = DateTime.TryParseExact(
            $"{Year}-{Month}-{Day} {Hour}:{Minute}:{Second}",
            "yyyy-M-d H:m:s",
            null,
            DateTimeStyles.None,
            out var time
        );

        if (success)
        {
            _playbackTime = time;
            _timeChanging = false;
        }
    }

    private void OnTimeChanged(object? sender, MediaPlayerTimeChangedEventArgs e)
    {
        if (_timeChanging) return;

        _playbackTime = _time + TimeSpan.FromMilliseconds(e.Time);

        SyncTime();
    }

    private void SyncTime()
    {
        Year = _playbackTime.Year.ToString();
        Month = _playbackTime.Month.ToString();
        Day = _playbackTime.Day.ToString();
        Hour = _playbackTime.Hour.ToString();
        Minute = _playbackTime.Minute.ToString();
        Second = _playbackTime.Second.ToString();
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
