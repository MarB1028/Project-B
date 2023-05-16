using ConsoleTables;
using System.Xml.Linq;

public static class FoodConfigure
{
    public static void ShowAllCatering()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Clear();

        List<Food> Foods = DataFood.ReadFoodFromJson("All");
        Console.WriteLine(" [MENU] ");
        var table = new ConsoleTable("Number", "Name", "Description", "Type", "Price");

        foreach (var item in Foods)
        {
            table.AddRow(item.ID, item.Name, item.Description, item.Type, $"€ {item.Price},-");
        }
        Console.WriteLine(table);
        
        Console.WriteLine("\n1: [ADD FOOD TO CATERING]");
        Console.WriteLine("2: [REMOVE FOOD FROM CATERING]");
        Console.WriteLine("3: [GO BACK]");

        string input;
        do
        {
            Console.Write(": ");
            input = Console.ReadLine();
            if (input == "1" || input == "2" || input == "3")
            {
                break;
            }
            else Console.WriteLine("INVALID INPUT");

        } while (true);

        if (input == "1")
        {
            AddFoodForm();
        }

        else if (input == "2")
        {
            RemoveFood();
        }

        else if (input == "3")
        {
            StartFoodConfigure();
        }
    }
    
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
        Thread.Sleep(3000);
        ShowAllCatering();
    }

    public static void FoodAdd(string name, double price, string desc, string type)
    {
        List<Food> Foods = DataFood.ReadFoodFromJson("All");
        List<int> ints = Foods.Select(n => n.ID).ToList();

        int highestId;
        if (ints.Count == 0) highestId = 1;
        else highestId = ints.Max() + 1;

        Food food = new Food(highestId, name, price, desc, type);

        if (DataFood.WriteFoodToJson(food))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{food.Name.ToUpper()} SUCCESSFULLY ADDED TO STORE...");
            Console.WriteLine("GOING BACK TO THE CATERING MENU...");
            Console.ResetColor();
        }

        else if (!DataFood.WriteFoodToJson(food))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n{food.Name.ToUpper()} ALREADY IN STORE");
            Console.WriteLine("GOING BACK TO THE CATERING MENU...");
            Console.ResetColor();
        }
    }

    public static void RemoveFood()
    {
        List<Food> foods = DataFood.ReadFoodFromJson("All");

        Console.WriteLine("\nPlease enter the number of the food you wish to remove");

        int foodid;
        Food temp = null;
        do
        {
            Console.Write(": ");
            foodid = Convert.ToInt32(Console.ReadLine());

            foreach (var item in foods)
            {
                if (item.ID == foodid)
                {
                    temp = item;
                    break;
                }
            }

            if (temp != null) break;
 
        } while (true);

        foods.Remove(temp);
        
        for (int i = 0; i < foods.Count; i++)
        {
            foods[i].ID = i + 1;
        }

        DataFood.OverWriteExistingFile(foods);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n{temp.Name.ToUpper()} REMOVED FROM THE STORE");
        Console.ResetColor();

        Thread.Sleep(2000);
        ShowAllCatering();
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
        Console.WriteLine("2: [GO BACK]");

        string input;
        do
        {
            Console.Write(": ");
            input = Console.ReadLine();
            if (input == "1" || input == "2")
            {
                break;
            }
        } while (true);

        if (input == "1")
        {
            Console.Clear();
            ShowAllCatering();
        }

        else if (input == "2")
        {
            AdminForm.StartForm();
        }
    }
}