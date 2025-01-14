using ShoppingListApp.Models;
using System.Windows.Input;

namespace ShoppingListApp.ViewModels;

public class EditProductViewModel : BaseViewModel
{
    public Product Product { get; set; }

    public ICommand SaveCommand { get; }

    public EditProductViewModel()
    {
        SaveCommand = new Command(async () => await SaveProductAsync());
    }

    private async Task SaveProductAsync()
    {
        await App.Database.SaveProductAsync(Product);
        await Application.Current.MainPage.Navigation.PopAsync();
    }
}
