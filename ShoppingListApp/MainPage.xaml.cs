﻿using ShoppingListApp.ViewModels;

namespace ShoppingListApp.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainPageViewModel();
    }
}
