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
        Console.WriteLine("Start the search for your next journey here.");
        Console.WriteLine("");
        Console.Write("Destinations:\n");
        Console.WriteLine("*Germany:\t\t1.1 Frankfurt\t\t1.2 Munchen");
        Console.WriteLine("*Spain:\t\t\t2.1 Barcelona\t\t2.2 Malaga");
        Console.WriteLine("*Greece:\t\t3.1 Athens\t\t3.2 Mykonos");
        Console.WriteLine("*United Kingdom:\t4.1 London\t\t4.2 Manchester");
        Console.WriteLine();

        OverviewFlights overview = new OverviewFlights();
        overview.ShowAvailableFlights();
    }
}