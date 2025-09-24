using DesignPatternBuilder;
using System.IO;

//////////////////////////////////////////
// CLIENT
//////////////////////////////////////////

List<House> houses = new List<House>();

    // Haus mit gewünschten Parametern erstellen
    houses.Add(new HouseBuilder()
                        .SetWalls("Brick")
                        .SetRoof("pitched roof")
                        .SetFloors(3)
                        .Build());

    // Standard-Haus erstellen
    IHouseBuilder houseBuilder = new HouseBuilder();
    HouseDirector director = new HouseDirector(houseBuilder);
    director.Construct();
    House defaultHouse = houseBuilder.Build();
    houses.Add(defaultHouse);

// Standard-Gartenhaus erstellen
    IHouseBuilder gardenMinHouse = new GardenHouseBuilder();
    GardenHouseDirector ghDirector = new GardenHouseDirector();
    ghDirector.BuildMinimalViableProduct();
    houses.Add(gardenMinHouse.Build());

    // leere Instanz erstellen (ohne Director)
    houses.Add(new HouseBuilder()
                        .Build());

// output
foreach (House house in houses)
    Console.WriteLine(house);