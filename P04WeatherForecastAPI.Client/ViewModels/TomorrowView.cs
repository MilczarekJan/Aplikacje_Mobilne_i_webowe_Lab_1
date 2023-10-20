using P04WeatherForecastAPI.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    public class TomorrowViewModel
    {
        internal TomorrowViewModel(Hour hour)
        {
            PhraseText = hour.GetPhraseText();
        }
        public string PhraseText { get; set; }
    }
}
