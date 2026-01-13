using CommunityToolkit.Mvvm.ComponentModel;

namespace CameraViewer.ViewModels;

public partial class CameraEditingWindowViewModel : ViewModelBase
{
    [ObservableProperty] private string _title = "编辑摄像机";
    
    public bool IsAdding
    {
        get;
        set
        {
            field = value;
            Title = value ? "添加摄像机" : "编辑摄像机";
        }
    }
}
