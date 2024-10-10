using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Wpf.Ui;
using WpfUiLab.Views.Pages;

namespace WpfUiLab.ViewModels.Pages;

public class HomePageViewModel : ObservableObject
{
    private readonly INavigationService _navigationService;

    public HomePageViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
        GoToSettingsCommand = new RelayCommand(GoToSettings);
    }
    
    public RelayCommand GoToSettingsCommand { get; }

    private void GoToSettings()
    {
        _navigationService.Navigate(typeof(SettingsPage));
    }
}