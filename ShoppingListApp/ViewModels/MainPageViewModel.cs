using System.Collections.ObjectModel;
using System.Windows.Input;
using ShoppingListApp.Models;
using ShoppingListApp.Services;

namespace ShoppingListApp.ViewModels;

public class MainPageViewModel : BaseViewModel
{
    // Kolekcja produktów wyświetlanych na liście
    public ObservableCollection<Product> Products { get; set; } = new();

    // Komendy do obsługi dodawania, edycji i usuwania produktów
    public ICommand AddProductCommand { get; }
    public ICommand EditProductCommand { get; }
    public ICommand DeleteProductCommand { get; }

    // Konstruktor inicjalizujący komendy i ładujący produkty z bazy danych
    public MainPageViewModel()
    {
        AddProductCommand = new Command(async () => await AddProductAsync()); // Komenda dodająca nowy produkt
        EditProductCommand = new Command<Product>(async (product) => await EditProductAsync(product)); // Komenda edytująca produkt
        DeleteProductCommand = new Command<Product>(async (product) => await DeleteProductAsync(product)); // Komenda usuwająca produkt

        LoadProducts(); // Ładowanie produktów z bazy danych
    }

    // Metoda ładująca produkty z bazy danych do kolekcji
    private async void LoadProducts()
    {
        var products = await App.Database.GetProductsAsync(); // Pobranie produktów z bazy danych
        Products.Clear(); // Wyczyszczenie obecnej listy
        foreach (var product in products) // Dodanie każdego produktu do kolekcji
        {
            Products.Add(product);
        }
    }

    // Metoda dodająca nowy produkt
    private async Task AddProductAsync()
    {
        var newProduct = new Product
        {
            Name = "Nowy produkt", // Domyślna nazwa produktu
            Unit = "szt.", // Domyślna jednostka
            Quantity = 1, // Domyślna ilość
            IsPurchased = false // ```csharp
            // Domyślna flaga zakupu
        };

        await App.Database.SaveProductAsync(newProduct); // Zapisanie nowego produktu w bazie danych
        LoadProducts(); // Ponowne załadowanie produktów
    }

    // Metoda edytująca istniejący produkt
    private async Task EditProductAsync(Product product)
    {
        // Logika edytowania produktu (np. otwarcie formularza edycji)
        await App.Database.SaveProductAsync(product); // Zapisanie zmian w produkcie
        LoadProducts(); // Ponowne załadowanie produktów
    }

    // Metoda usuwająca produkt
    private async Task DeleteProductAsync(Product product)
    {
        await App.Database.DeleteProductAsync(product); // Usunięcie produktu z bazy danych
        LoadProducts(); // Ponowne załadowanie produktów
    }
}