using P04WeatherForecastAPI.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    public class RegionViewModel
    {
        internal RegionViewModel(Region administrativeArea)
        {
            FoundName = administrativeArea.regionName;
        }
        public string FoundName { get; set; }
    }
}
