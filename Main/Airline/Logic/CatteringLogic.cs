using ConsoleTables;
using System;

static class CatteringLogic
{
    public static List<BasketItem> basketItems = new List<BasketItem>();
    public static double TotalPrice;
    
    public static string CheckFlightDur(Flight flight)
    {
        if ((flight.Destination.FlightDuration * 60) > 90) return "Long";
        else return "Short";
    }

    public static void CatteringShowMenu(Flight flight)
    {   
        Console.Clear();

        List<Food> Foods = DataFood.ReadFoodFromJson(CheckFlightDur(flight));
        Console.WriteLine(" [MENU] ");
        var table = new ConsoleTable("Name", "Description", "Price");

        foreach (var item in Foods)
        {
            table.AddRow(item.Name, item.Description, item.Price.ToString("C"));
        }
        Console.WriteLine(table);
    }

    public static void FoodSelect(Flight flight)
    {
        Console.Clear();
        CatteringShowMenu(flight);
        Console.WriteLine("\nPlease type the food you want");
        Console.Write(": ");
        string input = Console.ReadLine();
               
        if (FindFood(input, flight) == null)
        {
            do
            {
                Console.WriteLine($"{input} not found in menu please choose again");
                Console.WriteLine("Please select a new type of food again");
                Console.Write(": ");
                input = Console.ReadLine();
                
                if (FindFood(input, flight) != null)
                {
                    break;
                }
            }
            while (true);
        }

        Console.Write("\nAmount: ");
        int amount = Convert.ToInt32(Console.ReadLine());

        foreach (BasketItem i in basketItems)
        {
            if (i.FoodItem.Name == input)
            {
                i.Quantity += amount;
                Console.WriteLine($"{amount} sucessfully added to {i.FoodItem.Name}");
                Thread.Sleep(3000);
                StartCattering(flight);
            }

        }

        Console.WriteLine("Food sucessfully added to basket...");
        basketItems.Add(new BasketItem(FindFood(input, flight), amount));
        Thread.Sleep(3000);
        StartCattering(flight);
    }

    public static void ShowBasket(Flight flight)
    {
        Console.WriteLine(" [BASKET] ");
        var basket = new ConsoleTable("Name", "Amount", "Price");

        foreach (var item in basketItems)
        {
            basket.AddRow(item.FoodItem.Name, $"x {item.Quantity}", item.FoodItem.Price.ToString("C"));
        }
        Console.WriteLine(basket);

        Console.WriteLine("\n1: [GO BACK]");
        Console.WriteLine("2: [REMOVE ITEM]");
        Console.Write(": ");
        string input = Console.ReadLine();

        if (input == "1")
        {
            StartCattering(flight);
        }

        else if (input == "2")
        {
            Console.WriteLine("Please enter the food you wish to remove");
            Console.Write(": ");
            string food = Console.ReadLine();

            if (FindFood(food, flight) == null)
            {
                do
                {
                    Console.WriteLine($"{food} not found in menu please choose again");
                    Console.WriteLine("Please select again.");
                    Console.Write(": ");
                    food = Console.ReadLine();

                    if (FindFood(food, flight) != null)
                    {
                        break;
                    }
                }
                while (true);
            }

            BasketItem item = basketItems.FirstOrDefault(p => p.FoodItem.Name == food);
            basketItems.Remove(item);

            Console.WriteLine($"{food} succesfully removed from basket");
            Thread.Sleep(3000);
            StartCattering(flight);
        }
    }

    public static void Finalize(Flight flight)
    {
        Console.Clear();
        Console.WriteLine(" [CHECKOUT] ");
        var basket = new ConsoleTable("Name", "Amount", "Price");

        foreach (var item in basketItems)
        {
            basket.AddRow(item.FoodItem.Name, $"x {item.Quantity}", item.FoodItem.Price.ToString("C"));
        }
        Console.WriteLine(basket);

        double totalprice = 0;
        foreach (var item in basketItems)
        {
            double price = item.FoodItem.Price * item.Quantity;
            totalprice += price;
        }

        Console.WriteLine($"\n[TOTAL PRICE: ${totalprice}]");
        Console.WriteLine($"\n1: [CONTINUE PAYMENT]");
        Console.WriteLine($"2: [GO BACK]");
        string input = Console.ReadLine();

        if (input == "1")
        {
            Console.WriteLine("N/A");
            TotalPrice = totalprice;
            //TODO: hier moet je naar het betalingsysteem gestuurd worden
        }

        else if (input == "2")
        {
            StartCattering(flight);
        }
    }
    
    public static Food FindFood(string foodname, Flight flight)
    {
        List<Food> Foods = DataFood.ReadFoodFromJson(CheckFlightDur(flight));
        foreach (var item in Foods)
        {
            if (item.Name == foodname)
            {
                return item;
            }
        }
        return null;
    }

    public static void StartCattering(Flight flight)
    {
        CatteringShowMenu(flight);
        Console.WriteLine("\n1: [SELECT FOOD]");
        Console.WriteLine("2: [VIEW BASKET]");
        Console.WriteLine("3: [FINALIZE]");
        Console.WriteLine("4: [QUIT]");
        Console.Write(": ");

        string input = Console.ReadLine();

        if (input == "1")
        {
            FoodSelect(flight);
        }

        else if (input == "2")
        {
            Console.Clear();
            ShowBasket(flight);
        }

        else if (input == "3")
        {
            Finalize(flight);
        }
    }
}   