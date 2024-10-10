using WpfUiLab.ViewModels.Pages;

namespace WpfUiLab.Views.Pages;

public partial class UsersPage
{
    public UsersPage(UsersPageViewModel viewModel)
    {
        InitializeComponent();
        ViewModel = viewModel;
        DataContext = this;
    }

    public UsersPageViewModel ViewModel { get; }
}