using Future.Context;
using Microsoft.AspNetCore.Components.WebView.Maui;
using Microsoft.EntityFrameworkCore;
using FPOSMenuMaker.Services;
using Future.Util;
using Blazored.Modal;
using Microsoft.Maui.LifecycleEvents;
using System;
using System.Runtime.InteropServices;
using FPOSMenuMaker;


namespace FPOSMenuMaker;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();
        builder.Services.AddSingleton<CurrentItemSelectionHandler>();
        builder.Services.AddBlazoredModal();
        builder.Services.AddBlazorWebViewDeveloperTools();

#if WINDOWS
        builder.ConfigureLifecycleEvents(events =>
        {
            events.AddWindows(wndLifeCycleBuilder =>
            {
                wndLifeCycleBuilder.OnWindowCreated(window =>
                {
                    IntPtr hWnd = WinRT.Interop.WindowNative.GetWindowHandle(window);
                    PInvoke.User32.ShowWindow(hWnd, PInvoke.User32.WindowShowStyle.SW_SHOWMAXIMIZED);
                });
            });
        });
#endif

#if DEBUG
        builder.Services.AddDbContext<FPOSContext>((options) =>
        {
            options.UseSqlServer("Server=Tyler-Desktop\\SQLEXPRESS;Database=Blue Ribbon;Trusted_Connection=True;TrustServerCertificate=True");

        });
#else
        builder.Services.AddDbContext<FPOSContext>((options) =>
		{
			var connectionString = $"Server={DbInfo.serverName};Database={DbInfo.dbName};Trusted_Connection=True;TrustServerCertificate=True";
            options.UseSqlServer(Environment.ExpandEnvironmentVariables(connectionString));
        });
#endif

        return builder.Build();
    }
}
