using System.Windows.Controls;
using WpfUiLab.ViewModels.Pages;

namespace WpfUiLab.Views.Pages;

public partial class SettingsPage : Page
{
    public SettingsPage(SettingsPageViewModel viewModel)
    {
        InitializeComponent();
        ViewModel = viewModel;
        DataContext = this;
    }

    public SettingsPageViewModel ViewModel { get; }
}