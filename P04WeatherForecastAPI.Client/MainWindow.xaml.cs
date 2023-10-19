using P04WeatherForecastAPI.Client.Models;
using P04WeatherForecastAPI.Client.Services;
using P04WeatherForecastAPI.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace P04WeatherForecastAPI.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel;
        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
            //accuWeatherService = new AccuWeatherService();
        }
        /*
        private async void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            
            City[] cities= await accuWeatherService.GetLocations(txtCity.Text);

            // standardowy sposób dodawania elementów
            //lbData.Items.Clear();
            //foreach (var c in cities)
            //    lbData.Items.Add(c.LocalizedName);

            // teraz musimy skorzystac z bindowania danych bo chcemy w naszej kontrolce przechowywac takze id miasta 
            lbData.ItemsSource = cities;
        }

        private async void lbData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCity= (City)lbData.SelectedItem;
            if(selectedCity != null)
            {
                var weather = await accuWeatherService.GetCurrentConditions(selectedCity.Key);
                string nearbyNeighbours = await accuWeatherService.GetNearby(selectedCity.Key);//moje
                string tomorrowWeather = await accuWeatherService.GetPredictionOneDay(selectedCity.Key);//moje2
                string hourWeather = await accuWeatherService.GetPredictionOneHour(selectedCity.Key);//moje3
                string adminValue = await accuWeatherService.GetAdminInfo(selectedCity.Key);//moje4
                string yesterdayValue = await accuWeatherService.GetPastInfo(selectedCity.Key);//moje5
                lblCityName.Content = selectedCity.LocalizedName;
                double tempValue = weather.Temperature.Metric.Value;
                lblTemperatureValue.Content = Convert.ToString(tempValue);
                lblNeighbourValue.Content = nearbyNeighbours;//moje
                lblTomorrowValue.Content = tomorrowWeather;//moje2
                lblHourValue.Content = hourWeather;//moje3
                lblAdminValue.Content = adminValue;//moje4
                lblYesterdayValue.Content = yesterdayValue;//moje5
            }
        }
        */
    }
}
