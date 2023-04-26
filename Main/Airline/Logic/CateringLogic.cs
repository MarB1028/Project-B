using ConsoleTables;

static class CateringLogic
{   
    public static List<BasketItem> basketItems = new List<BasketItem>();
    public static double TotalPrice = 0;
    
    // CHECKT DE DURATION VAN DE VLUCHT. LANGER DAN 90 = LONG, KORTER DAN 90 = SHORT
    public static string CheckFlightDur(Flight flight)
    {
        if ((flight.Destination.FlightDuration * 60) > 90) return "Long";
        else return "Short";
    }

    // LAAT HET MENU ZIEN MET ALLE BESCHIKBARE ETEN, MET BEHULP VAN CONSOLETABLES
    public static void CateringShowMenu(Flight flight)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Clear();

        List<Food> Foods = DataFood.ReadFoodFromJson(CheckFlightDur(flight));
        Console.WriteLine(" [MENU] ");
        var table = new ConsoleTable("Number", "Name", "Description", "Price");

        foreach (var item in Foods)
        {
            table.AddRow(item.ID, item.Name, item.Description, $"€ {item.Price},-");
        }
        Console.WriteLine(table);
    }

    // DE FUNCTIE OM ETEN TE KIEZEN MET DE GEGEVEN ID
    public static void FoodSelect(Flight flight)
    {
        Console.Clear();
        CateringShowMenu(flight);
        Console.WriteLine("\nPlease type number of the food you want");
        Console.Write(": ");
        int foodid = Convert.ToInt32(Console.ReadLine());
               
        if (FindFood(foodid, flight) == null)
        {
            do
            {
                Console.WriteLine($"Item was not found in menu, please choose again");
                Console.WriteLine("Please select a new type of food again");
                Console.Write(": ");
                foodid = Convert.ToInt32(Console.ReadLine());

                if (FindFood(foodid, flight) != null)
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
            if (i.FoodItem.ID == foodid)
            {
                i.Quantity += amount;
                Console.WriteLine($"{amount} sucessfully added to {i.FoodItem.Name}");
                Thread.Sleep(3000);
                StartCatering(flight);
            }

        }

        Console.WriteLine("Food sucessfully added to basket...");
        basketItems.Add(new BasketItem(FindFood(foodid, flight), amount));
        Thread.Sleep(3000);
        StartCatering(flight);
    }

    // LAAT DE BASKET ZIEN MET ALLE ITEMS DIE ERIN ZITTEN
    public static void ShowBasket(Flight flight)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine(" [BASKET] ");
        var basket = new ConsoleTable("Number", "Name", "Amount", "Price");

        foreach (var item in basketItems)
        {
            basket.AddRow(item.FoodItem.ID, item.FoodItem.Name, $"x {item.Quantity}", $"€ {item.FoodItem.Price},-");
        }
        Console.WriteLine(basket);

        Console.WriteLine("\n1: [GO BACK]");
        Console.WriteLine("2: [REMOVE ITEM]");
        Console.Write(": ");
        string input = Console.ReadLine();

        if (input == "1")
        {
            StartCatering(flight);
        }

        else if (input == "2")
        {
            Console.WriteLine("Please enter the number of the food you wish to remove");
            Console.Write(": ");
            int foodid = Convert.ToInt32(Console.ReadLine());

            if (FindFood(foodid, flight) == null)
            {
                do
                {
                    Console.WriteLine($"Item was not found in menu, please choose again");
                    Console.WriteLine("Please select again.");
                    Console.Write(": ");
                    foodid = Convert.ToInt32(Console.ReadLine());

                    if (FindFood(foodid, flight) != null)
                    {
                        break;
                    }
                }
                while (true);
            }

            BasketItem item = basketItems.FirstOrDefault(p => p.FoodItem.ID == foodid);
            basketItems.Remove(item);

            Console.WriteLine($"Item succesfully removed from basket");
            Thread.Sleep(3000);
            StartCatering(flight);
        }
    }

    // DIT IS DE CHECKOUT FUNCTIE. HIJ PAKTE ALLE ITEMS EN LAAT DE TOTALPRIJS ZIEN
    public static void Finalize(Flight flight)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Clear();
        Console.WriteLine(" [CHECKOUT] ");
        var basket = new ConsoleTable("Name", "Amount", "Price");

        foreach (var item in basketItems)
        {
            basket.AddRow(item.FoodItem.Name, $"x {item.Quantity}", $"€ {item.FoodItem.Price},-");
        }
        Console.WriteLine(basket);

        foreach (var item in basketItems)
        {
            double price = item.FoodItem.Price * item.Quantity;
            TotalPrice += price;
        }

        Console.WriteLine($"\n[TOTAL PRICE: € {TotalPrice.ToString("F2")},-]");
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
            StartCatering(flight);
        }
    }
    
    // OBJECT FOOD VINDEN, OM CHECKS TE DOEN
    public static Food FindFood(int foodid, Flight flight)
    {
        List<Food> Foods = DataFood.ReadFoodFromJson(CheckFlightDur(flight));
        foreach (var item in Foods)
        {
            if (item.ID == foodid)
            {
                return item;
            }
        }
        return null;
    }

    // ENTRY POINT VAN CATERING
    public static void StartCatering(Flight flight)
    {
        CateringShowMenu(flight);
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