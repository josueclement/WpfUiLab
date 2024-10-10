using WpfUiLab.ViewModels.Pages;

namespace WpfUiLab.Views.Pages;

public partial class HomePage
{
    public HomePage(HomePageViewModel viewModel)
    {
        InitializeComponent();
        ViewModel = viewModel;
        DataContext = this;
    }

    public HomePageViewModel ViewModel { get; }
}