using ConsoleTables;
static class CatteringForm
{
    public static void Cattering(Flight flight)
    {
        var infomenu = new ConsoleTable("Country", "City", "Destination", "Boarding Date", "Arrival Date");

        Console.WriteLine(" [GENERAL FLIGHT INFORMATION]");
        infomenu.AddRow(flight.Destination.Country, flight.Destination.City, flight.Destination.Airport, flight.BoardingDate, flight.EstimatedArrival);
        Console.WriteLine(infomenu);


        Console.WriteLine($"\nYour flight to ({flight.Destination.Airport}-{flight.Destination.Country}-{flight.Destination.City})\nIs estimated to be: {flight.Destination.FlightDuration}m long\nWould you like to buy some food along the trip? (Y/N)");

        Console.Write(": ");
        string input = Console.ReadLine();
        if (input == "Y" || input == "y")
        {
            CatteringLogic.StartCattering(flight);
        }

        else if (input == "N" || input == "n")
        {
            Console.WriteLine("");
        }

        else
        {
            Console.WriteLine("Invalid input");
            Cattering(flight);
        }
    }
}