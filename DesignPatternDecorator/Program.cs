using DesignPatternDecorator;
using System;
using System.Text;

class Program
{
    static void Main()
    {
        List<ICoffee> coffees = new List<ICoffee>();

        // einfacher Kaffee
        ICoffee myCoffee = new Coffee();
        coffees.Add(myCoffee);

        // Kaffe mit Milch und Zucker (für Elke)
        myCoffee = new MilkDecorator(myCoffee);
        myCoffee = new SugarDecorator(myCoffee);
        Reservation allRes = new Reservation(myCoffee);
        allRes.MakeReservation("Elke");
        coffees.Add(allRes);

        // Eiskaffe mit Milch (für Hermann)
        myCoffee = new IceCoffee();
        myCoffee = new MilkDecorator(myCoffee);
        Reservation reservedCoffee = new Reservation(myCoffee);
        reservedCoffee.MakeReservation("Hermann");
        coffees.Add(reservedCoffee);
       
        ////////////////////////////////////////////////////////////////////////////
        /// Output
        Console.OutputEncoding = Encoding.UTF8; // Encoding um € Zeichen in der Konsole darzustellen

        foreach(ICoffee coffee in coffees)
        {
            Console.Write($"\n{coffee.Description()} kostet {coffee.Price():C}");
            if (coffee is Reservation)
            {
                Reservation resCoffee = (Reservation)coffee;
                if (!string.IsNullOrEmpty(resCoffee.ReservationName))
                    Console.Write($" Reservierungsname: {resCoffee.ReservationName}");
            }
        }
        Console.WriteLine();
    }
}
