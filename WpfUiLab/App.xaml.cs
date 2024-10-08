﻿using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Wpf.Ui;
using Wpf.Ui.DependencyInjection;
using WpfUiLab.Services;
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
            _ = services.AddLogging(builder =>
            {
                builder.ClearProviders();
                builder.SetMinimumLevel(LogLevel.Trace);
                builder.AddNLog();
            });
            
            _ = services.AddNavigationViewPageProvider();
            
            // Theme manipulation
            _ = services.AddSingleton<IThemeService, ThemeService>();
            
            // Service containing navigation, same as INavigationWindow... but without window
            _ = services.AddSingleton<INavigationService, NavigationService>();
            _ = services.AddSingleton<NavigationHelperService>();
            
            _ = services.AddSingleton<MainWindow>();
            _ = services.AddSingleton<MainWindowViewModel>();

            _ = services.AddSingleton<HomePage>();
            _ = services.AddSingleton<HomePageViewModel>();
            _ = services.AddSingleton<UsersPage>();
            _ = services.AddSingleton<UsersPageViewModel>();
            _ = services.AddTransient<UserFormPage>();
            _ = services.AddTransient<UserFormPageViewModel>();
            _ = services.AddSingleton<SettingsPage>();
            _ = services.AddSingleton<SettingsPageViewModel>();
        })
        .Build();

    /// <inheritdoc />
    protected override void OnStartup(StartupEventArgs e)
    {
        AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
        TaskScheduler.UnobservedTaskException += TaskSchedulerOnUnobservedTaskException;
        Current.DispatcherUnhandledException += CurrentOnDispatcherUnhandledException;
        _host.Start();
        
        Services.GetRequiredService<MainWindow>().Show();
    }

    /// <inheritdoc />
    protected override void OnExit(ExitEventArgs e)
    {
        AppDomain.CurrentDomain.UnhandledException -= CurrentDomainOnUnhandledException;
        TaskScheduler.UnobservedTaskException -= TaskSchedulerOnUnobservedTaskException;
        Current.DispatcherUnhandledException -= CurrentOnDispatcherUnhandledException;
        
        _host.StopAsync().Wait();
        _host.Dispose();
    }

    /// <summary>
    /// Get services
    /// </summary>
    // ReSharper disable once MemberCanBePrivate.Global
    public static IServiceProvider Services => _host.Services;

    private void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        var logger = Services.GetRequiredService<ILogger<App>>();
        if (e.ExceptionObject is Exception ex)
            logger.LogError(ex, "Unhandled exception");
        else
            logger.LogError("Unhandled exception");
        
        MessageBox.Show(e.ExceptionObject.ToString());
    }

    private void TaskSchedulerOnUnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs e)
    {
        Services.GetRequiredService<ILogger<App>>().LogError(e.Exception, "Unobserved task exception");
        MessageBox.Show(e.Exception.ToString());
    }

    private void CurrentOnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        Services.GetRequiredService<ILogger<App>>().LogError(e.Exception, "Dispatcher unhandled exception");
        MessageBox.Show(e.Exception.ToString());
        e.Handled = true;
    }
}