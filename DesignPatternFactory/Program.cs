using Factory.FactoryPatternExample;

TransportCreator transpCreator = null;
// Ein Creator für Trucks
transpCreator = new TruckCreator();
transpCreator.Deliver();

Console.WriteLine();

// Ein Creator für Schiff
transpCreator = new ShipCreator();
transpCreator.Deliver();

Console.ReadLine();