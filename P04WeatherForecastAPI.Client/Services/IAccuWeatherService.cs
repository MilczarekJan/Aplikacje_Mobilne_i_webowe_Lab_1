using P04WeatherForecastAPI.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.Services
{
    public interface IAccuWeatherService
    {
        Task<City[]> GetLocations(string locationName);
        Task<Weather> GetCurrentConditions(string cityKey);
        Task<Neighbour> GetNearby(string cityKey);
        Task<Hour> GetPredictionOneDay(string cityKey);
        Task<Hour> GetPredictionOneHour(string cityKey);
        Task<Region> GetAdminInfo(string cityKey);
        Task<Hour> GetPastInfo(string cityKey);
    }
}
