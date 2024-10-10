using WpfUiLab.ViewModels.Pages;

namespace WpfUiLab.Views.Pages;

public partial class UserFormPage
{
    public UserFormPage(UserFormPageViewModel viewModel)
    {
        InitializeComponent();
        ViewModel = viewModel;
        DataContext = this;
    }
    
    public UserFormPageViewModel ViewModel { get; }
}