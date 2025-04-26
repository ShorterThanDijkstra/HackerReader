using System.ComponentModel;
using System.IO;
using System.Reactive;
using System.Text.Encodings.Web;
using System.Web;
using ReactiveUI;
using WebViewControl;

namespace HackerReader.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private string _address;
    private string _currentAddress;

    public MainWindowViewModel(WebView webview)
    {
        Address = CurrentAddress = "";

        NavigateCommand = ReactiveCommand.Create(() => { CurrentAddress = Address; });

        PropertyChanged += OnPropertyChanged;
    }

    private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(CurrentAddress))
        {
            Address = CurrentAddress;
        }
    }

    public string Address
    {
        get => _address;
        set => this.RaiseAndSetIfChanged(ref _address, value);
    }

    public string CurrentAddress
    {
        get => _currentAddress;
        set => this.RaiseAndSetIfChanged(ref _currentAddress, value);
    }
    public string Filename {
        get
        {
            var address = HttpUtility.UrlDecode(_currentAddress);
            var index = address.LastIndexOf(Path.DirectorySeparatorChar) + 1;
            return address.Substring(index);
        }
    }

    public ReactiveCommand<Unit, Unit> NavigateCommand { get; }
    
}