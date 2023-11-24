using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using P10MAUI.Models;

namespace P10MAUI.Data
{
    public class GetShoeService
    {
		private const string base_url = "http://localhost:5093";
		private const string shoe_endpoint = "api/Shoe/GetShoe/{0}";
		private readonly HttpClient _httpClient;

		public GetShoeService() { 
			_httpClient = new HttpClient();
		}

		public async Task<Shoe> GetShoeFromApi(string shoeId)
		{
			var uri = base_url + "/" + string.Format(shoe_endpoint, shoeId);
			var response = await _httpClient.GetAsync(uri); //"http://localhost:5093/api/Shoe/GetShoe/1"
			var jsonResponse = await response.Content.ReadAsStringAsync();
			var responseObj = JsonConvert.DeserializeObject<JObject>(jsonResponse);
			bool success = responseObj.Value<bool>("success");
			if (success) //&& responseObj.Value<string>("data") != null
			{
				var shoeData = responseObj["data"].ToObject<Shoe>();
				return shoeData;
			}
			else
			{
				return null;
			}
			
		}
	}
}
