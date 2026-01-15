using Avalonia;
using Avalonia.Controls;

namespace CameraViewer.Controls;

public partial class TitleBar : UserControl
{
    public static readonly StyledProperty<string> TitleProperty =
        AvaloniaProperty.Register<TitleBar, string>(nameof(Title));
    
    public string Title
    {
        get => GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }
    
    public TitleBar()
    {
        InitializeComponent();
    }
}

