using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.Models
{

    public class Hour
    {
        private string phraseText;
        public Hour(string phraseText)
        {
            this.phraseText = phraseText;
        }
        public string GetPhraseText()
        {
            return this.phraseText;
        }
    }

}