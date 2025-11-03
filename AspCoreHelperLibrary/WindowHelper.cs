using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

// ReSharper disable SuggestVarOrType_Elsewhere
#pragma warning disable CA1806

namespace AspCoreHelperLibrary;

/// <summary>
/// Provides utility methods for managing and interacting with application windows,
/// including bringing processes to the foreground, displaying and customizing
/// console windows, and setting console titles in development environments.
/// </summary>
public static class WindowHelper
{

    /// <summary>
    /// Brings the specified process's main window to the foreground.
    /// </summary>
    /// <param name="process">
    /// The <see cref="Process"/> instance representing the process whose main window should be brought to the front.
    /// </param>
    /// <remarks>
    /// If the window is minimized, it will be restored before being brought to the foreground.
    /// </remarks>
    public static void BringProcessToFront(Process process)
    {
        IntPtr handle = process.MainWindowHandle;
        if (IsIconic(handle))
        {
            ShowWindow(handle, SwRestore);
        }

        SetForegroundWindow(handle);
    }

    /// <summary>
    /// Displays the console window for the application in development mode and optionally sets its title.
    /// </summary>
    /// <param name="app">
    /// The <see cref="WebApplication"/> instance representing the current application.
    /// </param>
    /// <param name="title">
    /// An optional string to set as the console window's title. Defaults to an empty string.
    /// </param>
    /// <remarks>
    /// This method only takes effect when the application is running in development mode.
    /// If a console window matching the application's main window title is found, it is brought to the foreground.
    /// If a title is provided, the console window's title is updated.
    /// </remarks>
    public static void ShowConsoleWindow(this WebApplication app, string title = "")
    {
        if (!app.Environment.IsDevelopment())
        {
            return;
        }

        Process[] processes = Process.GetProcesses();

        var consoleWindowTitle = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
            string.Concat(AppDomain.CurrentDomain.FriendlyName, ".exe"));

        foreach (var process in processes)
        {
            if (string.IsNullOrWhiteSpace(process.MainWindowTitle)) continue;
            if (process.MainWindowTitle == consoleWindowTitle)
            {
                BringProcessToFront(process);

                if (!string.IsNullOrWhiteSpace(title))
                {
                    SetWindowText(process.MainWindowHandle, title);
                }
            }
        }
    }


    /// <summary>
    /// Sets the console window title specifically for Windows 11 environments.
    /// </summary>
    /// <param name="app">The web application instance.</param>
    /// <param name="title">The desired title for the console window.</param>
    /// <remarks>
    /// This method updates the console title for both classic console hosts and VT-aware hosts
    /// (e.g., Windows Terminal). It also handles scenarios where no console is attached, such as
    /// when running as a service or under IIS Express.
    /// </remarks>
    /// <exception cref="IOException">
    /// Thrown when no console is attached or output is redirected. The exception is caught and handled internally.
    /// </exception>
    public static void SetConsoleWindowTitleWindows11(this WebApplication app, string title)
    {
        if (!app.Environment.IsDevelopment())
            return;

        try
        {
            // Works on classic conhost and Windows Terminal
            Console.Title = title;

            // Belt-and-suspenders for VT-aware hosts (Windows Terminal)
            Console.Write($"\x1b]0;{title}\x07");
        }
        catch (IOException)
        {
            // No console is attached (e.g., service, IIS Express, or output redirected)
            // Swallow or log as needed.
        }
    }


    const int SwRestore = 9;

    [DllImport("User32.dll")]
    private static extern bool SetForegroundWindow(IntPtr handle);
    [DllImport("User32.dll")]
    private static extern bool ShowWindow(IntPtr handle, int nCmdShow);
    [DllImport("User32.dll")]
    private static extern bool IsIconic(IntPtr handle);
    [DllImport("user32.dll")]
    static extern int SetWindowText(IntPtr hWnd, string text);
}
