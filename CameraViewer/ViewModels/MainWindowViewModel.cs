using System.Collections.ObjectModel;
using CameraViewer.Models;

namespace CameraViewer.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
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
