using DesignPatternObserver;

WeatherStation station = new WeatherStation();

TemperatureDisplay display1 = new TemperatureDisplay("Display 1");
TemperatureDisplay display2 = new TemperatureDisplay("Display 2");


station.RegisterObserver(display1);
station.RegisterObserver(display2);

station.SetTemperature(22.5f);
Console.WriteLine();

station.RegisterObserver(new TemperatureDisplay("Display 3"));

station.SetTemperature(25.0f);
Console.WriteLine();

station.RemoveObserver(display2);

station.SetTemperature(26.2f);
Console.WriteLine();