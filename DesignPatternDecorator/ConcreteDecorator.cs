using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternDecorator
{
    public class MilkDecorator : CoffeeDecorator
    {
        public MilkDecorator(ICoffee kaffee) : base(kaffee) { }

        public override string Description()
        {
            return _kaffee.Description() + ", Milch";
        }
        public override double Price() { 
            return _kaffee.Price() + 0.50;
        }
    }

    public class SugarDecorator : CoffeeDecorator
    {
        public SugarDecorator(ICoffee kaffee) : base(kaffee) { }

        public override string Description()
        {
            return _kaffee.Description() + ", Zucker";
        }
        public override double Price() {
            return _kaffee.Price() + 0.20; 
        }
    }

    /// <summary>
    /// Fügt der Komponente eine neue Funktionalität hinzu
    /// </summary>
    public class Reservation: CoffeeDecorator
    {
        public Reservation(ICoffee kaffee) : base(kaffee) { }

        public string ReservationName { get; set; }

        public void MakeReservation(string name)
        {
            ReservationName = name;
        }

        public void UndoReservation()
        {
            ReservationName = string.Empty;
        }
    }
}
