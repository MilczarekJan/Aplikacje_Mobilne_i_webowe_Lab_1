using P04WeatherForecastAPI.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    public class AdminViewModel
    {
        internal AdminViewModel(AdministrativeArea administrativeArea)
        {
            FoundName = administrativeArea.LocalizedName;
        }
        public string FoundName { get; set; }
    }
}
