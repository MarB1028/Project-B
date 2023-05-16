public class FlightHeader
{
    public static void Header()
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("STEP 1/5 of the booking process: Choose your flight");
        Console.WriteLine("======================================================");
        Console.ResetColor(); /* Vermelden waar we naar toe vliegen */
        Console.WriteLine("\n");
        Deals.PrintDeals();
        Console.WriteLine("Start the search for your next journey here");
        Console.WriteLine("");
        Console.Write("Destinations\n");
        Console.WriteLine("*Germany:\t\t- Frankfurt\t\t- Munchen");
        Console.WriteLine("*Spain:\t\t\t- Barcelona\t\t- Malaga");
        Console.WriteLine("*Greece:\t\t- Athens\t\t- Mykonos");
        Console.WriteLine("*United Kingdom:\t- London\t\t- Manchester");
        Console.WriteLine();

        OverviewFlights overview = new OverviewFlights();
        overview.ShowAvailableFlights();
    }
}