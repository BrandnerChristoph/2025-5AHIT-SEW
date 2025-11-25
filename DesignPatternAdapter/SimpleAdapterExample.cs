using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternAdapter
{
    // Target
    interface Target
    {
        int CalculateValue(float value);
    }

    // Adapter
    class Adapter : Target
    {
        ICalculator adaptee;    // Instanz des Adaptee

        public Adapter(ICalculator calc)
        {
            this.adaptee = calc;
        }

        public int CalculateValue(float value)
        {
            int castedValue = (int)value;
            return this.adaptee.CalculateValue(castedValue);
        }
    }

     

    // Adaptee Interface
    interface ICalculator
    {
        int CalculateValue(int value);
    }

    class CalculatorMultiplication : ICalculator
    {
        public int CalculateValue(int value) { 
            return value * value; 
        }
    }
}
