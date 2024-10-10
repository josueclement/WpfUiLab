using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Wpf.Ui;
using WpfUiLab.Views.Pages;

namespace WpfUiLab.ViewModels.Pages;

public class UsersPageViewModel : ObservableObject
{
    private readonly INavigationService _navigationService;

    public UsersPageViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
        AddUserCommand = new RelayCommand(AddUser);
    }
    
    public RelayCommand AddUserCommand { get; }

    private void AddUser()
    {
        _navigationService.NavigateWithHierarchy(typeof(UserFormPage));
    }
}