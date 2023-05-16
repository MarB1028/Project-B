static class Deals
{
    public static void PrintDeals()
    {
        CalculateStartPrice.ApplyDeals();
        List<Flight> flights = DataFlights.ReadFlightsFromJson();
        Console.WriteLine("\n============================= Last Minute Deals =============================\n");
        Console.WriteLine("Save up to 75% on flights departing in the next 6 hours! Limited seats available.");

        bool dealsAvailable = false;
        foreach (Flight flight in flights)
        {
            if (flight.IsDeal == true)
            {
                dealsAvailable = true;
            }
        }

        if (dealsAvailable == false)
        {
            Console.WriteLine("There are no last minute deals at the moment.\n");
        }
        else
        {
            Console.WriteLine($"{"Flight No",-12} {"Destination",-18} {"Departure",-20} {"Price"}");

            foreach (Flight flight in flights)
            {
                if (flight.IsDeal == true)
                {   
                    flight.FlightNo ++; //FlightNo updaten 
                    Flight fl = flight;
                    Console.OutputEncoding = System.Text.Encoding.UTF8; // weergave euro tekens
                    Console.Write($"{fl.FlightNo,-12} {fl.Destination.City, -18} {fl.BoardingDate.ToString("yyyy-MM-dd HH:mm"),-20} from ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"€{Math.Round(fl.BasePrice * Math.Pow(1.1, 14), 2)},-");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($" to ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"€{Math.Round(fl.MinPrice, 2)},-\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            Console.WriteLine("\n");
            Console.WriteLine("\n");
        }
    }
}