using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.Models
{

public class Neighbour
{
        private string LocalizedName;
        public Neighbour(string LocalizedName) { 
            this.LocalizedName = LocalizedName;
        }
        public string GetLocalizedName()
        {
            return this.LocalizedName;
        }
}

}