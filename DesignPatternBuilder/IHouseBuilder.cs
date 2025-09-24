using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternBuilder
{
    public interface IHouseBuilder
    {
        IHouseBuilder SetDoorType(string doorType);
        IHouseBuilder SetFloors(int floors);
        IHouseBuilder SetRoof(string roof);
        IHouseBuilder SetWalls(string walls);
        IHouseBuilder SetWindows(int windows);

        void SetDoorType();
        void SetFloors();
        void SetRoof();
        void SetWalls();
        void SetWindows();

        House Build();
    }
}
