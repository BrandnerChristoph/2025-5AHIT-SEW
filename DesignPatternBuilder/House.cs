using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternBuilder
{

    // Product (komplexes Objekt für den ein Builder Pattern bereitgestellt werden soll)
    public class House
    {
        public string Walls { get; set; }
        public int Floors { get; set; }
        public string Roof { get; set; }
        public int Windows { get; set; }
        public string DoorType { get; set; }


        public override string ToString()
        {
            return $"Haus mit: {Walls}, {Floors}, {Roof}, {Windows}, {DoorType}";
        }
    }
}
