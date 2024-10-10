using WpfUiLab.ViewModels.Pages;

namespace WpfUiLab.Views.Pages;

public partial class SettingsPage
{
    public SettingsPage(SettingsPageViewModel viewModel)
    {
        InitializeComponent();
        ViewModel = viewModel;
        DataContext = this;
    }

    public SettingsPageViewModel ViewModel { get; }
}