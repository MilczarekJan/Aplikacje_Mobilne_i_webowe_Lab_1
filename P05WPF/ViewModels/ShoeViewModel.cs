using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using P06Shop.Shared.Shop;

public class ShoeViewModel : INotifyPropertyChanged
{
    private string apiBaseUrl = "http://localhost:5093/";
    private ApiClient apiClient;
    private int selectedShoeId;

    public int SelectedShoeId
    {
        get { return selectedShoeId; }
        set
        {
            selectedShoeId = value;
            OnPropertyChanged();
        }
    }

    public List<Shoe> Shoes { get; set; } // You can bind this to a UI element

    public Shoe SelectedShoe { get; set; } // You can bind this to a UI element

    public ShoeViewModel()
    {
        apiClient = new ApiClient(apiBaseUrl);
        LoadShoes();
    }

    public async Task LoadShoes()
    {
        var result = await apiClient.GetShoesAsync();
        Shoes = result.Data;
        OnPropertyChanged(nameof(Shoes));
    }

    public async Task GetShoe()
    {
        if (SelectedShoeId > 0)
        {
            var result = await apiClient.GetShoeAsync(SelectedShoeId);
            SelectedShoe = result.Data;
            OnPropertyChanged(nameof(SelectedShoe));
        }
    }

    public async Task AddShoe(string name, string description)
    {
        var newShoe = new Shoe { Name = name, Description = description };
        await apiClient.AddShoeAsync(newShoe);
        LoadShoes();
    }

    public async Task DeleteShoe()
    {
        if (SelectedShoeId > 0)
        {
            var result = await apiClient.DeleteShoeAsync(SelectedShoeId);
            Console.WriteLine(result);
            LoadShoes();
        }
    }

    public async Task UpdateShoe(string name, string description)
    {
        if (SelectedShoeId > 0)
        {
            var updatedShoe = new Shoe { Name = name, Description = description };
            await apiClient.UpdateShoeAsync(SelectedShoeId, updatedShoe);
            LoadShoes();
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
