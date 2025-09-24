using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternBuilder
{
    // Builder
    public class GardenHouseBuilder : IHouseBuilder
    {
        private House _house = new House();

        public IHouseBuilder SetDoorType(string doorType)
        {
            _house.DoorType = "single Door";
            return this;
        }

        public IHouseBuilder SetFloors(int floors)
        {
            _house.Floors = floors;
            return this;
        }

        public IHouseBuilder SetRoof(string roof)
        {
            _house.Roof = roof;
            return this;
        }

        public IHouseBuilder SetWalls(string wall)
        {
            _house.Walls = "wood";
            return this;
        }

        public IHouseBuilder SetWindows(int windows)
        {
            _house.Windows = windows;
            return this;
        }

///////////////////////////////////////////////////////////////////
        public void SetDoorType()
        {
            throw new NotImplementedException();
        }

        public void SetFloors()
        {
            throw new NotImplementedException();
        }

        public void SetRoof()
        {
            throw new NotImplementedException();
        }

        public void SetWalls()
        {
            throw new NotImplementedException();
        }

        public void SetWindows()
        {
            throw new NotImplementedException();
        }

///////////////////////////////////////////////////////////////////
        public House Build()
        {
            return _house;
        }
    }
}
