using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using P06Shop.Shared.Shop;
using Microsoft.Extensions.Configuration;
using System.IO;
using P08WebApp;
using Newtonsoft.Json.Linq;
using P08WebApp.Models;

public class MyApiService : IMyApiService
{
    private readonly HttpClient _httpClient;
    private const string base_url = "http://localhost:5093";
    private const string shoeslist_endpoint = "api/Shoe/GetShoes";
    private const string shoe_endpoint = "api/Shoe/GetShoe/{0}";
    private const string delete_endpoint = "api/Shoe/DeleteShoe/{0}";

    public MyApiService()
    {
        _httpClient = new HttpClient();
        /*
        _httpClient.BaseAddress = new Uri(base_url);
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        */
    }

    public async Task<Shoe[]> GetShoesAsync()
    {
        var uri = string.Format(shoeslist_endpoint);
        var response = await _httpClient.GetAsync(uri);
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync();
        var shoes = JsonConvert.DeserializeObject<Shoe[]>(json);
        return shoes;
    }

    public async Task<Shoe> AddShoeAsync(Shoe shoe)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Shoe/newShoe", shoe);
        response.EnsureSuccessStatusCode();
        return shoe;
    }

    public async Task<Shoe> GetShoeAsync(int id)
    {
        var uri = base_url + "/" + string.Format(shoe_endpoint, id);
        var response = await _httpClient.GetAsync(uri);
        response.EnsureSuccessStatusCode();
        var jsonResponse = await response.Content.ReadAsStringAsync();

        var responseObj = JsonConvert.DeserializeObject<JObject>(jsonResponse);
        bool success = responseObj.Value<bool>("success");

        if (success)
        {
            var shoeData = responseObj["data"].ToObject<Shoe>();
            return shoeData;
        }
        else
        {
            string errorMessage = responseObj.Value<string>("message");
            throw new Exception(errorMessage);
        }
    }

    public async Task<DeleteViewModel> DeleteShoeAsync(int id)
    {
        var uri = base_url + "/" + string.Format(delete_endpoint, id);
        var response = await _httpClient.DeleteAsync(uri);
        response.EnsureSuccessStatusCode();
        var data = await response.Content.ReadAsStringAsync();
        DeleteViewModel isDeleted = JsonConvert.DeserializeObject<DeleteViewModel>(data);
        return isDeleted;
    }

    public async Task<Shoe> UpdateShoeAsync(int id, Shoe updatedShoe)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/Shoe/UpdateShoe/{id}", updatedShoe);
        response.EnsureSuccessStatusCode();
        var data = await response.Content.ReadAsStringAsync();
        Shoe shoe = JsonConvert.DeserializeObject<Shoe>(data);
        return shoe;
    }

}
