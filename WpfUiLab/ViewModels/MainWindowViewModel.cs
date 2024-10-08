using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfUiLab.ViewModels;

public class MainWindowViewModel : ObservableObject
{
    public ObservableCollection<object> NavigationItems { get; } = [];
    public ObservableCollection<object> FooterNavigationItems { get; } = [];
}