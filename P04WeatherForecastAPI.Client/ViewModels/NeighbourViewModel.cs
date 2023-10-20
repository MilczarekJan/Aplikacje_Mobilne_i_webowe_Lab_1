using P04WeatherForecastAPI.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    public class NeighbourViewModel
    {
        internal NeighbourViewModel(Neighbour neighbour)
        {
            NeighbourName = neighbour.GetLocalizedName();
        }
        public string NeighbourName { get; set; }
    }
}
