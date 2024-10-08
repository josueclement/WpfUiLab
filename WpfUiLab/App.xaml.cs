using System;
using System.IO;
using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Wpf.Ui;
using Wpf.Ui.Abstractions;
using Wpf.Ui.DependencyInjection;
using WpfUiLab.ViewModels;
using WpfUiLab.ViewModels.Pages;
using WpfUiLab.Views;
using WpfUiLab.Views.Pages;

namespace WpfUiLab;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{
    // ReSharper disable once InconsistentNaming
    private static readonly IHost _host = Host.CreateDefaultBuilder()
        .ConfigureAppConfiguration(c =>
        {
            var basePath =
                Path.GetDirectoryName(AppContext.BaseDirectory)
                ?? throw new DirectoryNotFoundException(
                    "Unable to find the base directory of the application."
                );
            _ = c.SetBasePath(basePath);
        })
        .ConfigureServices((_1, services) =>
        {
            _ = services.AddNavigationViewPageProvider();
            
            // Theme manipulation
            _ = services.AddSingleton<IThemeService, ThemeService>();
            
            // Service containing navigation, same as INavigationWindow... but without window
            _ = services.AddSingleton<INavigationService, NavigationService>();
            
            // // Main window with navigation
            // _ = services.AddSingleton<INavigationWindow, MainWindow>();
            // _ = services.AddSingleton<ViewModels.MainWindowViewModel>();
            // _ = services.AddSingleton<INavigationWindow, MainWindow>();
            _ = services.AddSingleton<MainWindow>();
            _ = services.AddSingleton<MainWindowViewModel>();

            _ = services.AddSingleton<HomePage>();
            _ = services.AddSingleton<HomePageViewModel>();
            _ = services.AddSingleton<SettingsPage>();
            _ = services.AddSingleton<SettingsPageViewModel>();
        })
        .Build();

    /// <inheritdoc />
    protected override void OnStartup(StartupEventArgs e)
    {
        _host.Start();
        
        Services.GetRequiredService<MainWindow>().Show();
    }

    /// <inheritdoc />
    protected override void OnExit(ExitEventArgs e)
    {
        _host.StopAsync().Wait();
        _host.Dispose();
    }

    /// <summary>
    /// Get services
    /// </summary>
    // ReSharper disable once MemberCanBePrivate.Global
    public static IServiceProvider Services => _host.Services;
}