using System;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Reactive;
using System.Text.Encodings.Web;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using EpubSharp;
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
        // var book = EpubReader.Read("../../../test.epub");
        // var rootFilePath = book.Format.Ocf.RootFilePath;

        // var index = rootFilePath.IndexOf("/");
        // var oebps = rootFilePath.Substring(0, index);
        try
        {
            var oebps = "OEBPS";
            var zip = ZipFile.OpenRead("../../../test.epub");
            Console.WriteLine(zip);
            var entry = zip.GetEntry($"text/part0029.html");
            Console.WriteLine(entry);

            var content = new StreamReader(entry.Open()).ReadToEnd();
            webview.LoadHtml(content);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

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

    public string Filename
    {
        get
        {
            var address = HttpUtility.UrlDecode(_currentAddress);
            var index = address.LastIndexOf(Path.DirectorySeparatorChar) + 1;
            return address.Substring(index);
        }
    }

    public ReactiveCommand<Unit, Unit> NavigateCommand { get; }
}