using System;
using Avalonia.Controls;
using CameraViewer.ViewModels;

namespace CameraViewer.Views;

public partial class CameraEditingWindow : Window
{
    public CameraEditingWindow()
    {
        InitializeComponent();
        
        DataContextChanged += (_, _) =>
        {
            var viewModel = DataContext as CameraEditingWindowViewModel ?? throw new Exception("无法获取 ViewModel");
            viewModel.Close = Close;
        };
    }
}

