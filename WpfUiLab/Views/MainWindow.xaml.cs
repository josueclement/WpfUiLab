﻿using System;
using System.Windows;
using Wpf.Ui;
using Wpf.Ui.Controls;
using WpfUiLab.Controls;
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

    public MainWindow(MainWindowViewModel viewModel,
        INavigationService navigationService,
        NavigationHelperService navigationHelperService)
    {
        _navigationService = navigationService;
        _navigationHelperService = navigationHelperService;
        
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
        
        if (_navigationHelperService.CurrentPage is NavigationPageBase page)
        {
            page.OnDisappeared();
            _navigationHelperService.CurrentPage = null;
        }
        Application.Current.Shutdown();
    }

    private void RootNavigationOnNavigating(NavigationView sender, NavigatingCancelEventArgs args)
    {
        if (_navigationHelperService.CurrentPage is NavigationPageBase page)
            page.OnDisappeared();
    }

    private void RootNavigationOnNavigated(NavigationView sender, NavigatedEventArgs args)
    {
        _navigationHelperService.CurrentPage = args.Page;
        if (_navigationHelperService.CurrentPage is NavigationPageBase page)
            page.OnAppeared();
    }
}