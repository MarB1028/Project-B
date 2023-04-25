using ConsoleTables;
static class CatteringForm
{
    public static void Cattering(Flight flight, List<BookTicket> tickets)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("STEP 4/5: Option to select Cattering (Y/N)");
        Console.WriteLine("======================================================");
        Console.ResetColor();
        Console.WriteLine();

        var infomenu = new ConsoleTable("Country", "City", "Destination", "Boarding Date", "Arrival Date");

        Console.WriteLine(" [GENERAL FLIGHT INFORMATION]");
        infomenu.AddRow(flight.Destination.Country, flight.Destination.City, flight.Destination.Airport, flight.BoardingDate, flight.EstimatedArrival);
        Console.WriteLine(infomenu);


        Console.WriteLine($"\nYour flight to ({flight.Destination.Country}-{flight.Destination.City}-{flight.Destination.Airport})\nIs estimated to be: {flight.Destination.FlightDuration * 60}m long\nWould you like to buy some food along the trip? (Y/N)");

        Console.Write(": ");
        string input = Console.ReadLine();
        if (input == "Y" || input == "y")
        {
            CatteringLogic.StartCattering(flight);

            CalculateTotalCosts.tickets = tickets;
            //hier berekent hij de totale prijs voor de tickets
            Console.WriteLine(CalculateTotalCosts.GetTotalPrice());
            
        }

        else if (input == "N" || input == "n")
        {
            Console.WriteLine("");
        }

        else
        {
            Console.WriteLine("Invalid input");
            Thread.Sleep(1000);
            Console.Clear();
            Cattering(flight, tickets);
        }
    }
}