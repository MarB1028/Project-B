public static class AdminForm
{
    public static void StartForm()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("[ADMIN: CONTROL PANNEL]");
        Console.WriteLine("======================================================");
        Console.ResetColor();
        Console.WriteLine();

        Console.WriteLine("1: [CONFIGURE FLIGHTS]");
        Console.WriteLine("2: [CONFIGURE CATERING]");
        Console.WriteLine("3: [LOG-OUT ADMIN PANNEL]");

        string input;
        do
        {
            Console.Write(": ");
            input = Console.ReadLine();
            if (input == "1" || input == "2" || input == "3")
            {
                break;
            }

        } while (true);
        
        if (input == "1")
        {
            FlightsConfigure.StartFlightConfigure();
        }

        else if (input == "2")
        {
            FoodConfigure.StartFoodConfigure();
        }

        else if (input == "3")
        {
            
        }
    }
}