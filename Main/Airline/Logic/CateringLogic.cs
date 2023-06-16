using ConsoleTables;

public static class CateringLogic
{
    public static List<BasketItem> basketItems = new List<BasketItem>();
    public static List<BookTicket> tickets;
    public static double TotalPrice = 0;

    public static void ResetTotalPrice()
    {
        TotalPrice = 0;
    }

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
    public static void FoodSelect(Flight flight, List<BookTicket> ticket)
    {
        int foodid;
        do
        {
            try
            {
                Console.Write("Select Food: ");
                foodid = Convert.ToInt32(Console.ReadLine());

                if (foodid > 0 && FindFood(foodid, flight) != null)
                {
                    break;
                }
                else Console.WriteLine("INVALID FOOD.");
            }

            catch (FormatException)
            {
                Console.WriteLine("Invalid number. Please enter a valid number.");
            }

        } while (true);

        int amount;
        do
        {
            try
            {
                Console.Write("Select amount: ");
                amount = Convert.ToInt32(Console.ReadLine());
                if (amount > 0 && amount <= 10)
                {
                    break;
                }
                else Console.WriteLine("INVALID AMOUNT.");
            }

            catch (FormatException)
            {
                Console.WriteLine("Invalid amount. Please enter a valid amount.");
            }

        } while (true);

        bool foundInBasket = false;
        foreach (BasketItem i in basketItems)
        {
            if (i.FoodItem.ID == foodid)
            {
                i.Quantity += amount;
                Console.WriteLine($"{amount} successfully added to {i.FoodItem.Name}");
                foundInBasket = true;
                break;
            }
        }

        if (!foundInBasket)
        {
            Console.WriteLine($"{FindFood(foodid, flight).Name} successfully added to basket...");
            basketItems.Add(new BasketItem(FindFood(foodid, flight), amount));
        }

        Thread.Sleep(3000);
        StartCatering(flight, ticket);
    }

    // LAAT DE BASKET ZIEN MET ALLE ITEMS DIE ERIN ZITTEN
    public static void ShowBasket(Flight flight, List<BookTicket> ticket)
    {
        Console.Clear();

        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine(" [BASKET] ");
        var basket = new ConsoleTable("Number", "Name", "Amount", "Price");

        for (int i = 0; i < basketItems.Count; i++)
        {
            var item = basketItems[i];
            basket.AddRow(item.FoodItem.ID, item.FoodItem.Name, $"x {item.Quantity}", $"€ {item.FoodItem.Price},-");
        }

        Console.WriteLine(basket);

        Console.WriteLine("\n1: [GO BACK]");
        Console.WriteLine("2: [REMOVE ITEM]");
        Console.Write(": ");

        string input;
        do
        {
            input = Console.ReadLine();
            Console.Write(": ");
            if (!string.IsNullOrEmpty(input))
            {
                if (input == "1" || input == "2")
                {
                    break;
                }
            }
        } while (true);

        if (input == "1")
        {
            StartCatering(flight, ticket);
        }

        else if (input == "2")
        {

            if (basketItems.Count == 0)
            {
                Console.WriteLine("Basket is empty!");
                Thread.Sleep(2000);
                StartCatering(flight, ticket);
            }

            Console.WriteLine("Please enter the number of the food you wish to remove");

            int foodid;
            do
            {
                string userinput = Console.ReadLine();
                Console.Write(": ");

                if (int.TryParse(userinput, out foodid))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }

            } while (true);


            bool itemFound = false;
            for (int i = basketItems.Count - 1; i >= 0; i--)
            {
                var item = basketItems[i];
                if (item.FoodItem.ID == foodid)
                {
                    basketItems.RemoveAt(i);
                    itemFound = true;
                    break;
                }
            }

            if (itemFound)
            {
                Console.WriteLine("Item successfully removed from the basket.");
            }
            else
            {
                Console.WriteLine("Item not found in the basket.");
            }

            Thread.Sleep(3000);
            ShowBasket(flight, ticket);
        }
    }

    // DIT IS DE CHECKOUT FUNCTIE. HIJ PAKTE ALLE ITEMS EN LAAT DE TOTALPRIJS ZIEN
    public static void Finalize(Flight flight, List<BookTicket> ticket)
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

        CalculateTotalCost();
        Console.WriteLine($"\n[TOTAL PRICE: € {TotalPrice.ToString("F2")},-]");
        Console.WriteLine($"\n1: [CONTINUE PAYMENT]");
        Console.WriteLine($"2: [GO BACK]");
        Console.Write(":");

        string input;
        do
        {
            input = Console.ReadLine();
            Console.Write(":");
            if (!string.IsNullOrEmpty(input))
            {
                if (input == "1" || input == "2")
                {
                    break;
                }
            }

        } while (true);

        if (input == "1")
        {
            Console.WriteLine("N/A");
            ConfirmTicketInformation.Tickets = tickets;
            ConfirmTicketInformation.PaymentScreen();
        }

        else if (input == "2")
        {
            StartCatering(flight, ticket);
        }
    }

    public static void CalculateTotalCost()
    {
        double tempPrice = 0;
        foreach (var item in basketItems)
        {
            double price = item.FoodItem.Price * item.Quantity;
            tempPrice += price;
        }

        TotalPrice = tempPrice;
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
    public static void StartCatering(Flight flight, List<BookTicket> ticket)
    {
        CateringShowMenu(flight);
        Console.WriteLine("\n1: [SELECT FOOD]");
        Console.WriteLine("2: [VIEW BASKET]");
        Console.WriteLine("3: [CHECK-OUT]");
        Console.WriteLine("4: [CANCEL]");

        string input;
        do
        {
            Console.Write(": ");
            input = Console.ReadLine();
            if (input == "1" || input == "2" || input == "3" || input == "4")
            {
                break;
            }

        } while (true);

        if (input == "1")
        {
            FoodSelect(flight, ticket);
        }

        else if (input == "2")
        {
            Console.Clear();
            ShowBasket(flight, ticket);
        }

        else if (input == "3")
        {
            Finalize(flight, ticket);
        }

        else if (input == "4")
        {
            CateringForm.Catering(flight, ticket);
        }
    }
}