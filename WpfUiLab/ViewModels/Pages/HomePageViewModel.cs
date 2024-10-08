using System.Threading.Tasks;
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
        GoToSettingsCommand = new AsyncRelayCommand(GoToSettings);
    }
    
    public AsyncRelayCommand GoToSettingsCommand { get; }

    private async Task GoToSettings()
    {
        _navigationService.Navigate(typeof(SettingsPage));
    }
}