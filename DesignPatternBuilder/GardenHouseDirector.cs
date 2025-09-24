using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternBuilder
{
    public class GardenHouseDirector
    {
        public House Construct(IHouseBuilder houseBuilder)
        {
            return houseBuilder.SetDoorType("single door")
                                .SetFloors(1)
                                .SetRoof("Flat")
                                .SetWalls("wood")
                                .Build();

        }
    }
}
