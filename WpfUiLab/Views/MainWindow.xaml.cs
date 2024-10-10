using System;
using System.Windows;
using Microsoft.Extensions.Logging;
using Wpf.Ui;
using Wpf.Ui.Abstractions;
using Wpf.Ui.Controls;
using WpfUiLab.Interfaces;
using WpfUiLab.Services;
using WpfUiLab.ViewModels;
using WpfUiLab.Views.Pages;

namespace WpfUiLab.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow
{
    private readonly INavigationService _navigationService;
    private readonly NavigationHelperService _navigationHelperService;
    private readonly ILogger<MainWindow> _logger;

    public MainWindow(MainWindowViewModel viewModel,
        INavigationService navigationService,
        NavigationHelperService navigationHelperService,
        ILogger<MainWindow> logger)
    {
        _navigationService = navigationService;
        _navigationHelperService = navigationHelperService;
        _logger = logger;
        
        InitializeComponent();
        ViewModel = viewModel;
        DataContext = this;
        navigationService.SetNavigationControl(RootNavigation);
        
        Loaded += OnLoaded;
        Closed += OnClosed;
        RootNavigation.Navigating += RootNavigationOnNavigating;
        RootNavigation.Navigated += RootNavigationOnNavigated;

        Wpf.Ui.Appearance.SystemThemeWatcher.Watch(this);
        // Wpf.Ui.Appearance.ApplicationThemeManager.Apply(
        //     Wpf.Ui.Appearance.ApplicationTheme.Dark, // Theme type
        //     Wpf.Ui.Controls.WindowBackdropType.Mica,  // Background type
        //     true                                      // Whether to change accents automatically
        // );
    }
    
    public MainWindowViewModel ViewModel { get; }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        _navigationService.Navigate(typeof(HomePage));
    }

    private void OnClosed(object? sender, EventArgs e)
    {
        RootNavigation.Navigating -= RootNavigationOnNavigating;
        RootNavigation.Navigated -= RootNavigationOnNavigated;
        _navigationHelperService.CurrentPage = null;
        Application.Current.Shutdown();
    }

    private void RootNavigationOnNavigating(NavigationView sender, NavigatingCancelEventArgs args)
    {
        if (_navigationHelperService.CurrentPage is INavigationPage page)
            page.OnDisappeared();
        _logger.LogDebug("Navigating to {pageType}", args.Page.GetType());
    }

    private void RootNavigationOnNavigated(NavigationView sender, NavigatedEventArgs args)
    {
        _navigationHelperService.CurrentPage = args.Page;
        if (_navigationHelperService.CurrentPage is INavigationPage page)
            page.OnAppeared();
        _logger.LogDebug("Navigated to {pageType}", args.Page.GetType());
    }
}