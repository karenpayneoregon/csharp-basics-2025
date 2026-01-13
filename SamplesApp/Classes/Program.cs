using ConsoleConfigurationLibrary.Classes;
using ConsoleHelperLibrary.Classes;
using Microsoft.Extensions.DependencyInjection;
using SamplesApp.Classes.Core;
using Spectre.Console;
using System.Reflection;
using System.Runtime.CompilerServices;
using static ConsoleConfigurationLibrary.Classes.ApplicationConfiguration;

// ReSharper disable once CheckNamespace
namespace SamplesApp;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        var assembly = Assembly.GetEntryAssembly();
        var product = assembly?.GetCustomAttribute<AssemblyProductAttribute>()?.Product;

        Console.Title = product!;

        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);

        SetupLogging.Development();
        SpectreConsoleHelpers.UseEmojis();
        Setup();

    }
    private static void Setup()
    {
        var services = ConfigureServices();
        using var provider = services.BuildServiceProvider();
        var setup = provider.GetService<SetupServices>();
        setup.GetConnectionStrings();
        setup.GetEntitySettings();
    }

    private static Table CreateTable()
    {
        return new Table()
            .RoundedBorder().BorderColor(Color.LightSlateGrey)
            .AddColumn("[b]Name[/]")
            .AddColumn("[b]Index[/]")
            .AddColumn("[b]Start Index[/]")
            .AddColumn("[b]End Index[/]")
            .Alignment(Justify.Center)
            .Title("[white on chartreuse3]Month indexing[/]");
    }
}
