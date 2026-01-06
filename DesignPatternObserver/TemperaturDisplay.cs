using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternObserver
{
    public class TemperatureDisplay : IObserver
    {
        private string name;
        public TemperatureDisplay(string name)
        {
            this.name = name;
        }

        public void Update(float temperature)
        {
            System.Console.WriteLine($"{name}: Neue Temperatur = {temperature}°C");
        }
    }
}
