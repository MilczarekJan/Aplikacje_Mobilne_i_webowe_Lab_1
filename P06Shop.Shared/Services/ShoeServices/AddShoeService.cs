using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http.Json;
using P06Shop.Shared.Shop;

namespace P06Shop.Shared.Services.ShoeServices
{
	public class AddShoeService
	{
		private const string base_url = "https://p05shopapiwindows.azurewebsites.net"; //http://localhost:5093
        private const string add_endpoint = "api/Shoe/newShoe";
		private readonly HttpClient _httpClient;

		public AddShoeService()
		{
			_httpClient = new HttpClient();
		}
		public async Task<string> AddShoeFromApi(string shoeSize, string shoeName, string shoeDescription, string token)
		{
			string newshoesize = shoeSize;
			double shoeSizeAsDouble = double.Parse(newshoesize);
			AddShoeDto shoeToAdd = new AddShoeDto(shoeSizeAsDouble, shoeName, shoeDescription);
			var uri = base_url + "/" + add_endpoint;
			_httpClient.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", token));
			var response = await _httpClient.PostAsJsonAsync(uri, shoeToAdd);
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
				return "Blad dodawania";
			}
		}
	}
}
