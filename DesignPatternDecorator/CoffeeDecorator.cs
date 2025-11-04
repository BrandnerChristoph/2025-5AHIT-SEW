using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternDecorator
{

    // Decorator (Abstrakte Basisklasse)
    public abstract class CoffeeDecorator : ICoffee
    {
        protected ICoffee _kaffee;

        protected CoffeeDecorator(ICoffee kaffee)
        {
            _kaffee = kaffee;
        }

        public virtual string Description()
        {
            return _kaffee.Description();
        }
        public virtual double Price() {
            return _kaffee.Price(); 
        }
    }
}
