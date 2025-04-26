using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using HackerReader.ViewModels;
using WebViewControl;
namespace HackerReader.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        AvaloniaXamlLoader.Load(this);

        DataContext = new MainWindowViewModel(this.FindControl<WebView>("webview"));
    }
}