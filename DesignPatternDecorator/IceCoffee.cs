using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternDecorator
{
    public class IceCoffee : ICoffee
    {
        private double temperature;
        public string Description()
        {
            return "Eis-Kaffee";
        }

        public double Price()
        {
            return 2.49;
        }
    }
}
