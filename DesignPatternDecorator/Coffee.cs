using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternDecorator
{
    // konkrete Komponente (Basisklasse)
    public class Coffee : ICoffee
    {
        public string Description()
        {
            return "Einfacher Kaffee";
        }
        public double Price()
        {
            return 2;
        }
    }
}
