using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using P06Shop.Shared.Shop;

public class ApiClient
{
    private readonly HttpClient _httpClient;

    public ApiClient(string baseAddress)
    {
        _httpClient = new HttpClient { BaseAddress = new Uri(baseAddress) };
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task GetShoesAsync()
    {
        var response = await _httpClient.GetAsync("api/Shoe");
        response.EnsureSuccessStatusCode();
        var data = await response.Content.ReadAsStringAsync();
        Console.WriteLine(data);
    }

    public async Task AddShoeAsync(Shoe shoe)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Shoe/newShoe", shoe);
        response.EnsureSuccessStatusCode();
        var data = await response.Content.ReadAsStringAsync();
        Console.WriteLine(data);
    }

    public async Task GetShoeAsync(int id)
    {
        var response = await _httpClient.GetAsync($"api/Shoe/GetShoe/{id}");
        response.EnsureSuccessStatusCode();
        var data = await response.Content.ReadAsStringAsync();
        Console.WriteLine(data);
    }

    public async Task DeleteShoeAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/Shoe/DeleteShoe/{id}");
        response.EnsureSuccessStatusCode();
        var data = await response.Content.ReadAsStringAsync();
        Console.WriteLine(data);
    }

    public async Task UpdateShoeAsync(int id, Shoe updatedShoe)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/Shoe/UpdateShoe/{id}", updatedShoe);
        response.EnsureSuccessStatusCode();
        var data = await response.Content.ReadAsStringAsync();
        Console.WriteLine(data);
    }

}
