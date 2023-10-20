using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
//using P04WeatherForecastAPI.Client.Commands;
//using P04WeatherForecastAPI.Client.DataSeeders;
using P04WeatherForecastAPI.Client.Models;
using P04WeatherForecastAPI.Client.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    // przekazywanie wartosci do innego formularza 
    public partial class MainViewModel : ObservableObject
    {
        private CityViewModel _selectedCity;
        private Weather _weather;
        private Neighbour _neighbour;
        private Region _administrativeArea;
        private Hour _hour;
        private Hour _yesterday;
        private Hour _tomorrow;

        private readonly IAccuWeatherService _accuWeatherService;

        public MainViewModel(IAccuWeatherService accuWeatherService)//, FavoriteCityViewModel favoriteCityViewModel, FavoriteCitiesView favoriteCitiesView
        {
            _accuWeatherService = accuWeatherService;
            Cities = new ObservableCollection<CityViewModel>(); // podejście nr 2 
        }

        [ObservableProperty]
        private WeatherViewModel weatherView;

        [ObservableProperty]
        private RegionViewModel regionView;

        [ObservableProperty]
        private NeighbourViewModel neighbourView;

        [ObservableProperty]
        private HourViewModel hourView;

        [ObservableProperty]
        private YesterdayViewModel yesterdayView;

        [ObservableProperty]
        private TomorrowViewModel tomorrowView;


        public CityViewModel SelectedCity
        {
            get => _selectedCity;
            set
            {
                _selectedCity = value;
                OnPropertyChanged();
                LoadWeather();
                LoadRegion();
                LoadNeighbour();
                LoadOneHour();
                LoadYesterday();
                LoadTomorrow();
            }
        }


        private async void LoadWeather()
        {
            if (SelectedCity != null)
            {
                _weather = await _accuWeatherService.GetCurrentConditions(SelectedCity.Key);
                WeatherView = new WeatherViewModel(_weather);
            }
        }


        private async void LoadRegion()
        {
            if (SelectedCity != null)
            {
                _administrativeArea = await _accuWeatherService.GetAdminInfo(SelectedCity.Key);
                RegionView = new RegionViewModel(_administrativeArea);
            }
        }

        private async void LoadNeighbour()
        {
            if (SelectedCity != null)
            {
                _neighbour = await _accuWeatherService.GetNearby(SelectedCity.Key);
                NeighbourView = new NeighbourViewModel(_neighbour);
            }
        }

        private async void LoadOneHour()
        {
            if (SelectedCity != null)
            {
                _hour = await _accuWeatherService.GetPredictionOneHour(SelectedCity.Key);
                HourView = new HourViewModel(_hour);
            }
        }

        private async void LoadYesterday()
        {
            if (SelectedCity != null)
            {
                _yesterday = await _accuWeatherService.GetPastInfo(SelectedCity.Key);
                YesterdayView = new YesterdayViewModel(_yesterday);
            }
        }

        private async void LoadTomorrow()
        {
            if (SelectedCity != null)
            {
                _tomorrow = await _accuWeatherService.GetPredictionOneDay(SelectedCity.Key);
                TomorrowView = new TomorrowViewModel(_tomorrow);
            }
        }

        // podajście nr 2 do przechowywania kolekcji obiektów:
        public ObservableCollection<CityViewModel> Cities { get; set; }

        [RelayCommand]
        public async void LoadCities(string locationName)
        {
            // podejście nr 2:
            var cities = await _accuWeatherService.GetLocations(locationName);
            Cities.Clear();
            foreach (var city in cities)
                Cities.Add(new CityViewModel(city));
        }
    }
}
