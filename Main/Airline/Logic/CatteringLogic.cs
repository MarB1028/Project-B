using System.Reflection.Metadata.Ecma335;

static class CatteringLogic
{
    public static bool CheckFlightDur(Flight flight)
    {
        if (flight.Destination.FlightDuration > 90) return true;
        else return false;
    }

    public static void CatteringShowMenu(Flight flight)
    {   
        // Prototype, subject to change
        Console.Clear();

        List<Food> LongFlightFoodlist = new List<Food>()
        {
            new Food("Hotdog", 3.75, "test", "Short"),
            new Food("Burger", 4.75, "test", "Short"),
            new Food("Fries", 2.75, "test", "Short"),
            new Food("Steak", 6.75, "test", "Short")
        };

        List<Food> SelectedFoods = new List<Food>()
        {
            new Food("Hotdog", 3.75, "test", "Short"),
        };

        
        Console.WriteLine("Name\tPrice\tDescription");
        Console.WriteLine("=================================");
        foreach (Food product in LongFlightFoodlist)
        {
            Console.WriteLine("{0}\t{1}\t{2:C}", product.Name, product.Price, product.Description);
        }
        Console.WriteLine("=================================");

        Console.WriteLine("\nBasket");
        Console.WriteLine("=================================");
        Console.WriteLine($"2 x {SelectedFoods[0].Name}, ${SelectedFoods[0].Price}");
        Console.WriteLine("=================================");

        Console.WriteLine("\nChoose a option");
        Console.WriteLine("1: [SELECT FOOD]");
        Console.WriteLine("2: [FINALIZE]");
        Console.WriteLine("3: [QUIT]");
    }
}   