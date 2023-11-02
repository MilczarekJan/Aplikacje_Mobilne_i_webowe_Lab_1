using System;
using System.Net.Http;
using System.Threading.Tasks;
using P06Shop.Shared.Shop;

class Program
{
    private readonly HttpClient _httpClient;
    private const string base_url = "http://localhost:5093";
    private const string shoeslist_endpoint = "api/Shoe/GetShoes";
    private const string shoe_endpoint = "api/Shoe/GetShoe/{0}";
    static async Task Main(string[] args)
    {
        // Replace with your API base address
        var apiBaseUrl = "http://localhost:5093/";
        var apiClient = new ApiClient(apiBaseUrl);

        // Test your API endpoints
        Console.WriteLine("Testing GetShoesAsync:");
        await apiClient.GetShoesAsync();

        /*
        Console.WriteLine("\nTesting AddShoeAsync:");
        var newShoe = new Shoe { Name = "Nike", Description = "Running shoe" };
        await apiClient.AddShoeAsync(newShoe);
        */
        Console.WriteLine("\nTesting GetShoeAsync:");
        await apiClient.GetShoeAsync(1); // Replace with a valid ID

        Console.WriteLine("\nTesting DeleteShoeAsync:");
        await apiClient.DeleteShoeAsync(1); // Replace with a valid ID

        Console.WriteLine("\nTesting Important:");
        /*
        Console.WriteLine("\nTesting UpdateShoeAsync:");
        var updatedShoe = new Shoe { Name = "Puma", Description = "Sneaker" };
        await apiClient.UpdateShoeAsync(1, updatedShoe); // Replace with a valid ID
        */
    }
}
