using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using P06Shop.Shared.Shop;

namespace P06Shop.Shared.Services.ShoeServices
{
    public class GetShoesService
    {
		private const string base_url = "https://shoeapi.azurewebsites.net"; //"http://localhost:5093";
		private const string shoeslist_endpoint = "api/Shoe";
		private readonly HttpClient _httpClient;

		public GetShoesService() { 
			_httpClient = new HttpClient();
		}

		public async Task<List<Shoe>> GetShoesFromApi(string token)
		{
			var uri = base_url + "/" + shoeslist_endpoint;
			_httpClient.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", token));
			var response = await _httpClient.GetAsync(uri); //"http://localhost:5093/api/Shoe/GetShoe/1"
			var jsonResponse = await response.Content.ReadAsStringAsync();
			var responseObj = JsonConvert.DeserializeObject<JObject>(jsonResponse);
			bool success = responseObj.Value<bool>("success");
			if (success) //&& responseObj.Value<string>("data") != null
			{
				var shoeData = responseObj["data"].ToObject<List<Shoe>>();
				return shoeData;
			}
			else
			{
				return null;
			}
			
		}
	}
}
