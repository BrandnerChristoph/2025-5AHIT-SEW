using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternBuilder
{
    // Builder
    public class HouseBuilder : IHouseBuilder
    {
        private House _house = new House();

        public IHouseBuilder SetDoorType(string doorType)
        {
            _house.DoorType = doorType;
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
            _house.Walls = wall;
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
            _house.DoorType = "single";
        }

        public void SetFloors()
        {
            _house.Floors = 2;
        }

        public void SetRoof()
        {
            _house.Roof = "pitched roof";

		}

        public void SetWalls()
        {
            _house.Walls = "concrete";
        }

        public void SetWindows()
        {
			_house.Windows = 5;
		}

///////////////////////////////////////////////////////////////////
		public House Build()
		{
			return _house;
		}
	}
}
