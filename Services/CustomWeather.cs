using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CustomWeather
    {
        public string Description { get; set; }
        private double temprature;
        public double Temprature
        {
            get => temprature;
            set
            {
                temprature = Math.Round(value - 273.15);
            }
        }

        public override string ToString()
        {
            return $"{Description}   -   {Temprature} ºC";
        }
    }
}
