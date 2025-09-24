using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternBuilder
{
    public class GardenHouseDirector
    {
        public IHouseBuilder Construct(IHouseBuilder houseBuilder)
        {
            return houseBuilder.SetDoorType("single door")
                                .SetFloors(1)
                                .SetRoof("Flat")
                                .SetWalls("wood");

        }

        public IHouseBuilder BuildMinimalViableProduct()
        {
            return new HouseBuilder().SetWalls("straw").SetWindows(0);
        }
    }
}
