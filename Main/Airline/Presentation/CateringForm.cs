using ConsoleTables;
using System.Collections.Generic;

static class CateringForm
{
    public static void Catering(Flight flight, List<BookTicket> tickets)
    {   
        Console.Clear();
        CateringLogic.tickets = tickets;
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("STEP 4/5: Option to select catering (Y/N)");
        Console.WriteLine("======================================================");
        Console.ResetColor();
        Console.WriteLine();

        var infomenu = new ConsoleTable("Country", "City", "Destination", "Boarding Date", "Arrival Date");

        Console.WriteLine(" [GENERAL FLIGHT INFORMATION]");
        infomenu.AddRow(flight.Destination.Country, flight.Destination.City, flight.Destination.Airport, flight.BoardingDate, flight.EstimatedArrival);
        Console.WriteLine(infomenu);


        Console.WriteLine($"\nYour flight to ({flight.Destination.Country}-{flight.Destination.City}-{flight.Destination.Airport})\nIs estimated to be: {flight.Destination.FlightDuration * 60} min long.\nWould you like to buy some food along the trip? (Y/N)");
        Console.WriteLine("BTW% are included in the price.");

        Console.Write(": ");
        string input = Console.ReadLine()!;
        if (input == "Y" || input == "y")
        {
            CateringLogic.StartCatering(flight, tickets);

            CalculateTotalCosts.tickets = tickets;
            //hier berekent hij de totale prijs voor de tickets
            Console.WriteLine(CalculateTotalCosts.GetTotalPrice());

            Menu.StartScreen();

        }

        else if (input == "N" || input == "n")
        {
            ConfirmTicketInformation.Tickets = tickets;

            Console.WriteLine();
            Console.Write("Press ENTER to continue...");
            Console.ReadLine();
            Console.Clear();

            ConfirmTicketInformation.PaymentScreen();
        }

        else
        {
            Console.WriteLine("Invalid input.");
            Thread.Sleep(1000);
            Console.Clear();
            Catering(flight, tickets);
        }
    }
}