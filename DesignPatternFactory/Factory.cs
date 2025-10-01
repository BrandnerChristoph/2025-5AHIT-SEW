using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    using System;

    namespace FactoryPatternExample
    {
        // Das Produkt-Interface deklariert eine gemeinsame Methode, die von allen konkreten Produkten implementiert wird.
        public interface ITransport
        {
            void Deliver();
        }

        // Konkretes Produkt 1: Truck
        public class Truck : ITransport
        {
            public void Deliver()
            {
                Console.WriteLine("Der Truck stellt die Sendung zu.");
            }
        }

        // Konkretes Produkt 2: Schiff
        public class Ship : ITransport
        {
            public void Deliver()
            {
                Console.WriteLine("Auf dem Wasserweg wird die Zustellung mittels Schiff vorgenommen.");
            }
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////
        // Die Creator-Klasse deklariert die Factory-Methode.
        // Diese Methode gibt ein Objekt vom Typ ITransport zurück.
        public abstract class TransportCreator
        {
            // Abstrakte Factory-Methode, die von den Unterklassen überschrieben wird.
            public abstract ITransport Create();

            // Diese Methode enthält Geschäftslogik,  die mit dem Produkt arbeitet.
            public void Deliver()
            {
                // Ein Fahrzeug wird über die Factory-Methode erzeugt.
                var fahrzeug = Create();

                Console.WriteLine("Starte Fahrt...");
                fahrzeug.Deliver();
            }
        }

        // Konkreter Creator 1: erzeugt Truck
        public class TruckCreator : TransportCreator
        {
            public override ITransport Create()
            {
                return new Truck();
            }
        }

        // Konkreter Creator 2: erzeugt Schif
        public class ShipCreator : TransportCreator
        {
            public override ITransport Create()
            {
                return new Ship();
            }
        }
    }

}
