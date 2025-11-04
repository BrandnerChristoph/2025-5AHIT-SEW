using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternDecorator
{
    // Komponente (Interface oder abstrakte Klasse)
    public interface ICoffee
    {
        string Description();
        double Price();
    }
}
