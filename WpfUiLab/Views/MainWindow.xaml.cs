using System;
using Wpf.Ui;
using Wpf.Ui.Abstractions;
using Wpf.Ui.Controls;
using WpfUiLab.ViewModels;
using WpfUiLab.Views.Pages;

namespace WpfUiLab.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow// : INavigationWindow
{
    public MainWindow(MainWindowViewModel viewModel, INavigationService navigationService)
    {
        InitializeComponent();
        DataContext = viewModel;
        navigationService.SetNavigationControl(RootNavigation);
        Loaded += (sender, args) =>
        {
            navigationService.Navigate(typeof(HomePage));
        };
        RootNavigation.Navigating += (sender, args) =>
        {

        };
        RootNavigation.Navigated += (sender, args) =>
        {

        };
        //navigationService.Navigate(typeof(HomePage));

        Wpf.Ui.Appearance.SystemThemeWatcher.Watch(this);
        // Wpf.Ui.Appearance.ApplicationThemeManager.Apply(
        //     Wpf.Ui.Appearance.ApplicationTheme.Dark, // Theme type
        //     Wpf.Ui.Controls.WindowBackdropType.Mica,  // Background type
        //     true                                      // Whether to change accents automatically
        // );
    }
    
    // public INavigationView GetNavigation()
    // {
    //     throw new NotImplementedException();
    // }
    //
    // public bool Navigate(Type pageType)
    //     => RootNavigation.Navigate(pageType);
    //
    // public void SetServiceProvider(IServiceProvider serviceProvider)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // public void SetPageService(INavigationViewPageProvider navigationViewPageProvider)
    //     => RootNavigation.SetPageProviderService(navigationViewPageProvider);
    //
    // public void ShowWindow()
    //     => Show();
    //
    // public void CloseWindow()
    //     => Close();
}