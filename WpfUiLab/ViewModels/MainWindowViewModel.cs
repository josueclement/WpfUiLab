using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfUiLab.ViewModels;

public class MainWindowViewModel : ObservableObject
{
    public ObservableCollection<object> NavigationItems { get; } = new ();
    public ObservableCollection<object> FooterNavigationItems { get; } = new ();
}