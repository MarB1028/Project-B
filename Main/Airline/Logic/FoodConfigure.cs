public static class FoodConfigure
{
    public static void AddFoodForm()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("[ADMIN: ADD FOOD TO CATERING MENU]");
        Console.WriteLine("======================================================");
        Console.ResetColor();
        Console.WriteLine();

        string name;
        do
        {    
            Console.Write("Food name: ");
            name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name))
            {
                break;
            }
            else Console.WriteLine("INVALID NAME");

        } while (true);

        double price;
        do
        {
            Console.Write("Food price: ");
            string input = Console.ReadLine();
            if (double.TryParse(input, out price))
            {
                break;
            }
            else Console.WriteLine("INVALID PRICE");

        } while (true);

        string desc;
        do
        {
            Console.Write("Food Description: ");
            desc = Console.ReadLine();
            if (!string.IsNullOrEmpty(desc))
            {
                break;
            }
            else Console.WriteLine("INVALID DESCRIPTION");

        } while (true);

        string type;
        do
        {
            Console.Write("Food Type: ");
            type = Console.ReadLine();
            if (type.ToLower() == "short" || type.ToLower() == "long")
            {
                break;
            }
            else Console.WriteLine("INVALID TYPE");

        } while (true);

        FoodAdd(name, price, desc, type);
        Console.WriteLine("Food succesfully added to store");
        Console.WriteLine("Going back to the start screen...");
        Thread.Sleep(3000);
        StartFoodConfigure();
    }

    public static void FoodAdd(string name, double price, string desc, string type)
    {
        Food food = new Food(name, price, desc, type);

        if (DataFood.WriteFoodToJson(food))
        {
            Console.WriteLine($"{food.Name} Succesfully added to store...");
        }

        else if (!DataFood.WriteFoodToJson(food))
        {
            Console.WriteLine($"{food.Name} Already in store");
        }
    }

    public static void StartFoodConfigure()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("[ADMIN: CONFIGURE FOODS]");
        Console.WriteLine("======================================================");
        Console.ResetColor();
        Console.WriteLine();

        Console.WriteLine("1: [VIEW CURRENT CATERING MENU]");
        Console.WriteLine("2: [ADD FOOD TO CATERING]");
        Console.WriteLine("3: [REMOVE FOOD FROM CATERING]");
        Console.WriteLine("4: [GO BACK]");

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

        if (input == "2")
        {
            Console.Clear();
            AddFoodForm();
        }
    }
}