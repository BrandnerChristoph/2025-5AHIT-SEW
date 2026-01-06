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
        public float Temperature { get; set; }

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
            Temperature = newTemperature;
            NotifyObservers();
        }

        public void NotifyObservers()
        {
            foreach (var observer in Observers)
            {
                // Variante: Pull (da das Subject nur benachrichtigt wird und sich die Daten selbst holen muss)
                observer.Update();
            }
        }
    }
}
