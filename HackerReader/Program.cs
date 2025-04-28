using Avalonia;
using Avalonia.ReactiveUI;
using System;
using System.IO;
using System.IO.Compression;
using System.Reflection;

namespace HackerReader;

sealed class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace()
            .UseReactiveUI();

    // public static void Main(string[] args)
    // {
    //     
    //     EpubBook book = EpubReader.Read("../../../test.epub");
    //     var contents = book.TableOfContents;
    //     foreach (var author in book.Authors)
    //     {
    //         Console.WriteLine(author);
    //     }
    //     foreach (var chapter in contents)
    //     {
    //         Console.WriteLine(chapter);
    //     }
    // }
    // public static void Main(string[] args)
    // {
        // var oebps = "OEBPS";
        // var zip = ZipFile.OpenRead("../../../test.epub");
        // Console.WriteLine(zip);
        // var entry = zip.GetEntry($"{oebps}/Text/part0002.xhtml");
        // Console.WriteLine(entry);
        //
        // var content = new StreamReader(entry.Open()).ReadToEnd();
        // Console.WriteLine(content);
    // }
}