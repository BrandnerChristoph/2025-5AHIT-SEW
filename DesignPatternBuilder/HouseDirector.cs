using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternBuilder
{
    public class HouseDirector
    {
        private IHouseBuilder _builder;

        public HouseDirector(IHouseBuilder builder)
        {
            _builder = builder;
        }

        public void Construct()
        {
            _builder.SetDoorType();
            _builder.SetFloors();
            _builder.SetRoof();
            _builder.SetWalls();
            _builder.SetWindows();
        }
    }
}
