using SQLite;

namespace ShoppingListApp.Models;

public class Product
{
    [PrimaryKey, AutoIncrement] // Id jest kluczem głównym i automatycznie inkrementowanym
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty; // Nazwa produktu

    public string Unit { get; set; } = string.Empty; // Jednostka miary (np. szt., kg, l)

    public int Quantity { get; set; } // Ilość produktu

    public bool IsPurchased { get; set; } // Flaga oznaczająca, czy produkt został zakupiony

    public Product() { } // Konstruktor domyślny
}