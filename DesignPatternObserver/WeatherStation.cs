using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternObserver
{
    public class WeatherStation : ISubject
    {
        public List<IObserver> Observers { get; set; } = new List<IObserver>();
        private float temperature;

        public void RegisterObserver(IObserver observer)
        {
            Observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            Observers.Remove(observer);
        }

        public void SetTemperature(float newTemperature)
        {
            temperature = newTemperature;
            NotifyObservers();
        }

        public void NotifyObservers()
        {
            foreach (var observer in Observers)
            {
                // Variante: Push (da das Subject bestimmt welche Daten gesendet werden)
                observer.Update(temperature);
            }
        }
    }
}
