using Microsoft.Maui;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using ShoppingListApp.Services;
using ShoppingListApp.ViewModels;
using ShoppingListApp.Views;

namespace ShoppingListApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Registering Services
        builder.Services.AddSingleton<DatabaseService>();

        // Registering ViewModels
        builder.Services.AddSingleton<MainPageViewModel>();
        builder.Services.AddTransient<EditProductViewModel>();

        // Registering Views
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<EditProductPage>();

        return builder.Build();
    }
}
