using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.TreasureFinder.ViewModels;

namespace Avalonia.TreasureFinder.Views;

public partial class ExceptionMessageView : UserControl
{
    public ExceptionMessageView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}