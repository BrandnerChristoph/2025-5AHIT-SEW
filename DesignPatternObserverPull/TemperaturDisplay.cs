using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternObserver
{
    public class TemperatureDisplay : IObserver
    {
        private WeatherStation station;
        public TemperatureDisplay(WeatherStation station)   // Referenz nötig
        {
            this.station = station;
        }

        public void Update()
        {
            float temp = station.Temperature;
            System.Console.WriteLine($"Temperatur: {temp}°C");
        }
    }
}
