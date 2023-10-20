using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using P04WeatherForecastAPI.Client.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.Services
{
    public class AccuWeatherService : IAccuWeatherService
    {
        private const string base_url = "http://dataservice.accuweather.com";
        private const string autocomplete_endpoint = "locations/v1/cities/autocomplete?apikey={0}&q={1}&language{2}";
        private const string current_conditions_endpoint = "currentconditions/v1/{0}?apikey={1}&language{2}";
        private const string nearby_cities_endpoint = "locations/v1/cities/neighbors/{0}?apikey={1}&language{2}"; //1szy endpoint
        private const string tomorrow_endpoint = "forecasts/v1/daily/1day/{0}?apikey={1}&language{2}"; //2gi endpoint
        private const string hour_endpoint = "forecasts/v1/hourly/1hour/{0}?apikey={1}&language{2}"; //3ci endpoint
        private const string info_endpoint = "locations/v1/{0}?apikey={1}&language{2}"; //4ty endpoint
        private const string past_endpoint = "currentconditions/v1/{0}/historical/24?apikey={1}&language{2}";//5ty endpoint

        private const string api_key = "sDifU3yWvy1be1j63hRHZTNFTQMpMRkz";//sDifU3yWvy1be1j63hRHZTNFTQMpMRkz XFLRjdOLGE0JmlAUDgiGBtt02y7xJR4X
        //string api_key;
        //private const string language = "pl";
        string language;

        public AccuWeatherService()
        {
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<App>()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetings.json"); 

            var configuration = builder.Build();
            //api_key = configuration["api_key"];
            language = configuration["default_language"];
        }


        public async Task<City[]> GetLocations(string locationName)
        {
            string uri = base_url + "/" + string.Format(autocomplete_endpoint, api_key, locationName, language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                City[] cities = JsonConvert.DeserializeObject<City[]>(json);
                return cities;
            }
        }
        public async Task<Neighbour> GetNearby(string cityKey)
        {
            string uri = base_url + "/" + string.Format(nearby_cities_endpoint, cityKey, api_key, language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                dynamic neighbours = JsonConvert.DeserializeObject<dynamic>(json);
                dynamic firstNeighbour = neighbours[0];
                Neighbour fNeighbour = new Neighbour(firstNeighbour["LocalizedName"].ToString());
                return fNeighbour;
            }
        }

        public async Task<Hour> GetPredictionOneDay(string cityKey)
        {
            string uri = base_url + "/" + string.Format(tomorrow_endpoint, cityKey, api_key, language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                dynamic weatherTomorrow = JsonConvert.DeserializeObject<dynamic>(json);
                Hour wTomorrow = new Hour(weatherTomorrow["DailyForecasts"][0]["Day"]["IconPhrase"].ToString());
                return wTomorrow;
            }
        }

        public async Task<Hour> GetPredictionOneHour(string cityKey)
        {
            string uri = base_url + "/" + string.Format(hour_endpoint, cityKey, api_key, language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                dynamic weatherHour = JsonConvert.DeserializeObject<dynamic>(json);
                Hour wHour = new Hour(weatherHour[0]["IconPhrase"].ToString());//weatherHour[0]["IconPhrase"].ToString()
                return wHour;
            }
        }

        public async Task<Region> GetAdminInfo(string cityKey)
        {
            string uri = base_url + "/" + string.Format(info_endpoint, cityKey, api_key, language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                dynamic adminInfo = JsonConvert.DeserializeObject<dynamic>(json);
                Region region = new Region(adminInfo["AdministrativeArea"]["LocalizedName"].ToString());
                return region;
            }
        }

        public async Task<Hour> GetPastInfo(string cityKey)
        {
            string uri = base_url + "/" + string.Format(past_endpoint, cityKey, api_key, language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                dynamic pastInfo = JsonConvert.DeserializeObject<dynamic>(json);
                Hour pInfo = new Hour(pastInfo[23]["WeatherText"].ToString());
                return pInfo;
            }
        }

        public async Task<Weather> GetCurrentConditions(string cityKey)
        {
            string uri = base_url + "/" + string.Format(current_conditions_endpoint, cityKey, api_key, language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                Weather[] weathers= JsonConvert.DeserializeObject<Weather[]>(json);
                return weathers.FirstOrDefault();
            }
        }
    }
}
