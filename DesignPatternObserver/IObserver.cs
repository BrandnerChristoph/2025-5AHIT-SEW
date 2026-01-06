using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternObserver
{
    public interface IObserver
    {
        void Update(float temperature); // Variante: Push
    }
}
