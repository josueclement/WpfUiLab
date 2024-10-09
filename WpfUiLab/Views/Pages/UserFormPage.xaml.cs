using System.Windows.Controls;
using WpfUiLab.ViewModels.Pages;

namespace WpfUiLab.Views.Pages;

public partial class UserFormPage : Page
{
    public UserFormPage(UserFormPageViewModel viewModel)
    {
        InitializeComponent();
        ViewModel = viewModel;
        DataContext = this;
    }
    
    public UserFormPageViewModel ViewModel { get; }
}