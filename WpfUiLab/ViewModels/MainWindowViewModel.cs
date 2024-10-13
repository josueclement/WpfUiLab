using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using MdiWpf;
using Wpf.Ui.Controls;
using WpfUiLab.Views.Pages;

namespace WpfUiLab.ViewModels;

public class MainWindowViewModel : ObservableObject
{
    public MainWindowViewModel()
    {
        if (!_isInitialized) 
            Initialize();
    }
    
    private bool _isInitialized = false;
    
    public ObservableCollection<object> NavigationItems { get; } = [];
    public ObservableCollection<object> FooterNavigationItems { get; } = [];

    private void Initialize()
    {
        NavigationItems.Add(new NavigationViewItem
        {
            Content = "Home",
            Icon = new SymbolIcon { Symbol = SymbolRegular.Home24 },
            TargetPageType = typeof(HomePage),
            ToolTip = "Home"
        });
        NavigationItems.Add(new NavigationViewItem
        {
            Content = "Users",
            Icon = new SymbolIcon { Symbol = SymbolRegular.Person24 },
            TargetPageType = typeof(UsersPage),
            ToolTip = "Users"
        });
        
        FooterNavigationItems.Add(new NavigationViewItem
        {
            Content = "Settings",
            Icon = new SymbolIcon { Symbol = SymbolRegular.Settings24 },
            TargetPageType = typeof(SettingsPage),
            ToolTip = "Settings"
        });
        
        _isInitialized = true;
    }
}