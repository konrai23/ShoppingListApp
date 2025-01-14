using SQLite;
using ShoppingListApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingListApp.Services;

public class DatabaseService
{
    private readonly SQLiteAsyncConnection _database; // Połączenie z bazą danych SQLite

    // Konstruktor inicjalizujący połączenie z bazą danych
    public DatabaseService(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath); // Inicjalizacja połączenia
        _database.CreateTableAsync<Product>().Wait(); // Tworzenie tabeli dla modelu Product, jeśli nie istnieje
    }

    // Pobieranie wszystkich produktów z bazy danych
    public Task<List<Product>> GetProductsAsync()
    {
        return _database.Table<Product>().ToListAsync(); // Zwraca listę produktów
    }

    // Zapisanie lub aktualizacja produktu w bazie danych
    public Task<int> SaveProductAsync(Product product)
    {
        if (product.Id != 0) // Jeśli produkt ma Id, to jest aktualizowany
        {
            return _database.UpdateAsync(product);
        }
        else // W przeciwnym razie jest dodawany jako nowy produkt
        {
            return _database.InsertAsync(product);
        }
    }

    // Usunięcie produktu z bazy danych
    public Task<int> DeleteProductAsync(Product product)
    {
        return _database.DeleteAsync(product); // Usuwa produkt z bazy danych
    }
}