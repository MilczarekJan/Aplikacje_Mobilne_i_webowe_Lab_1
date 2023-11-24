using System.Net.Http.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using P10MAUI.Models;

namespace P10MAUI.Data
{
    public class UpdateShoeService
    {
        private readonly HttpClient _httpClient;
        private const string base_url = "http://localhost:5093";
        private const string update_endpoint = "api/Shoe/UpdateShoe/{0}";

        public UpdateShoeService() { 
            _httpClient = new HttpClient();
        }
        public async Task<string> UpdateShoeFromApi(string shoeId, string shoeName, string shoeDescription, string shoeSize)
        {
            double shoeSizeAsDouble = double.Parse(shoeSize);
            AddShoeDto updatedShoe = new AddShoeDto(shoeSizeAsDouble, shoeName, shoeDescription);
            var uri = base_url + "/" + string.Format(update_endpoint, shoeId);
            var response = await _httpClient.PutAsJsonAsync(uri, updatedShoe);
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();

            var responseObj = JsonConvert.DeserializeObject<JObject>(jsonResponse);
            bool success = responseObj.Value<bool>("success");
            if (success) //&& responseObj.Value<string>("data") != null
            {
                return "Sukces";
            }
            else
            {
                return "Blad";
            }
        }
    }
}
