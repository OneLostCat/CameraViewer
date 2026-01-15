using System;
using CameraViewer.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
namespace CameraViewer.ViewModels;

public partial class CameraEditingWindowViewModel : ViewModelBase
{
    [ObservableProperty] private string _windowTitle = "编辑摄像机";
    [ObservableProperty] private string _cameraName = "";
    [ObservableProperty] private string _cameraCategory = "";
    [ObservableProperty] private string _cameraRecordingPath = "";
    
    public bool IsAdding
    {
        get;
        set
        {
            field = value;
            WindowTitle = value ? "添加摄像机" : "编辑摄像机";
        }
    }
    
    public Action<Camera>? Close { get; set; }

    [RelayCommand]
    private void Confirm()
    {
        Close?.Invoke(new Camera
        {
            Name = CameraName,
            Category = CameraCategory,
            RecordingPath = CameraRecordingPath
        });
    }
}
