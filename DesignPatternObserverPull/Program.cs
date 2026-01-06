using DesignPatternObserver;

WeatherStation station = new WeatherStation();

TemperatureDisplay display1 = new TemperatureDisplay(station);
TemperatureDisplay display2 = new TemperatureDisplay(station);


station.RegisterObserver(display1);
station.RegisterObserver(display2);

station.SetTemperature(22.5f);
Console.WriteLine();

station.RegisterObserver(new TemperatureDisplay(station));

station.SetTemperature(25.0f);
Console.WriteLine();

station.RemoveObserver(display2);

station.SetTemperature(26.2f);
Console.WriteLine();