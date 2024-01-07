using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace P06Shop.Shared.Services.ShoeServices
{
	public class DeleteShoeService
	{
		private const string base_url = "https://p05shopapiwindows.azurewebsites.net";
		private const string delete_endpoint = "api/Shoe/DeleteShoe/{0}";
		private readonly HttpClient _httpClient;
		public DeleteShoeService()
		{
			_httpClient = new HttpClient();
		}
		public async Task<string> DeleteShoeFromApi(string shoeId, string token)
		{
			var uri = base_url + "/" + string.Format(delete_endpoint, shoeId);
            if (!_httpClient.DefaultRequestHeaders.Contains("Authorization"))
            {
                _httpClient.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", token));
            }
            var response = await _httpClient.DeleteAsync(uri); //"http://localhost:5093/api/Shoe/GetShoe/1"
			var jsonResponse = await response.Content.ReadAsStringAsync();
			var responseObj = JsonConvert.DeserializeObject<JObject>(jsonResponse);
			bool success = responseObj.Value<bool>("success");
			if (success) //&& responseObj.Value<string>("data") != null
			{
				return "Pomyslnie usunieto";
			}
			else
			{
				return "Nie udalo sie usunac";
			}
		}
	}
}
