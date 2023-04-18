static class CatteringForm
{
    public static void CatteringMenu(Flight flight)
    {
        Console.WriteLine($"Your destination to: {flight.Destination.Airport} is ESTM {flight.Destination.FlightDuration}m");
        
        Console.WriteLine("\nFlight Info: ");
        Console.WriteLine("===============================================");
        Console.WriteLine($"Country: {flight.Destination.Country}");
        Console.WriteLine($"City: {flight.Destination.City}");
        Console.WriteLine($"Destination: {flight.Destination.Airport}");
        Console.WriteLine($"Boarding Date: {flight.BoardingDate}");
        Console.WriteLine($"Arrival Date: {flight.EstimatedArrival}");

        Console.WriteLine("\nWould you like to order some food allong with your travels? (Y/N)");

        Console.Write(": ");
        string input = Console.ReadLine();
        if ( input == "Y" || input ==  "y" )
        {
            CatteringLogic.CatteringShowMenu(flight);
        }

        else if (input == "N" || input == "n")
        {
            Console.WriteLine("");
        }

        else
        {
            Console.WriteLine("Invalid input");
            CatteringMenu(flight);
        }
    }
}