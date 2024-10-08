﻿using System.Windows.Controls;
using WpfUiLab.ViewModels.Pages;

namespace WpfUiLab.Views.Pages;

public partial class HomePage : Page
{
    public HomePage(HomePageViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}