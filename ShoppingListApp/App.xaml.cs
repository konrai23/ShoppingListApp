using Microsoft.Maui.Controls;
using ShoppingListApp.Services;
using ShoppingListApp.Views;

namespace ShoppingListApp;

public partial class App : Application
{
    public static DatabaseService Database { get; private set; } // Statyczna właściwość do dostępu do bazy danych

    public App()
    {
        InitializeComponent();

        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "ShoppingList.db"); // Ścieżka do bazy danych
        Database = new DatabaseService(dbPath); // Inicjalizacja bazy danych

        MainPage = new NavigationPage(new MainPage()); // Ustawienie głównej strony aplikacji
    }
}