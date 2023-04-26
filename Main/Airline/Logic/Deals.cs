static class Deals
{
    //De minimale prijs van de vlucht (MinPrice van een vluchtobject) wordt aangepast als de vertrektijd maximaal 6 uur korter is dan de huidige tijd
    public static void UpdateFlightPrice()
    {
        List<Flight> flights = DataFlights.ReadFlightsFromJson();
        DateTime now = DateTime.Now;
        foreach (Flight flight in flights)
        {
            double hoursleft = (flight.BoardingDate - now).TotalHours;

            if (hoursleft <= 3)
            {
                flight.MinPriceNet = flight.MinPrice * 0.25; // 75% korting
                flight.IsDeal = true;
            }
            else if (hoursleft <= 4)
            {
                flight.MinPriceNet = flight.MinPrice * 0.50; // 50% korting
                flight.IsDeal = true;
            }
            else if (hoursleft <= 5)
            {
                flight.MinPriceNet = flight.MinPrice * 0.75; // 25% korting   
                flight.IsDeal = true; 
            }
        }
        DataFlights.WriteDateToJson(flights);

    }

    public static void PrintDeals()
    {
        UpdateFlightPrice();
        List<Flight> flights = DataFlights.ReadFlightsFromJson();
        Console.WriteLine("==================== Last Minute Deals ====================\n");
        Console.WriteLine("Save up to 75% on flights departing in the next 6 hours! Limited seats available.\n");
        Console.WriteLine($"{"Flight No",-12} {"Destination",-18} {"Departure",-20} {"Price"}");

        foreach (Flight flight in flights)
        {
            if (flight.IsDeal == true)
            {   
                Flight fl = flight;
                Console.OutputEncoding = System.Text.Encoding.UTF8; // weergave euro tekens
                Console.Write($"{fl.FlightNo,-12} {fl.Destination.City, -18} {fl.BoardingDate.ToString("yyyy-MM-dd HH:mm"),-20} from ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"€{Math.Round(fl.MinPrice, 2)},-");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($" to ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"€{Math.Round(fl.MinPriceNet, 2)},-\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        Console.WriteLine("\n");
        Console.WriteLine("\n");
        Console.WriteLine("\n");
    }
}