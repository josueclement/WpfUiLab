using System.Text;
using System.Windows;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfUiLab.ViewModels;

namespace WpfUiLab.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow
{
    public MainWindow(MainWindowViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
        // Wpf.Ui.Appearance.ApplicationThemeManager.Apply(
        //     Wpf.Ui.Appearance.ApplicationTheme.Dark, // Theme type
        //     Wpf.Ui.Controls.WindowBackdropType.Mica,  // Background type
        //     true                                      // Whether to change accents automatically
        // );
    }
}