static class CalculateTotalCosts
{
    public static int amountOfLuggage;
    public static int amountOfHandLuggage;

    public static void CostsAllLuggage()
    {
        CheckInHandLuggage();
        CheckInLuggage();

        double totalCost = amountOfHandLuggage * 25.0 + amountOfLuggage * 55.0;
        double price1 = amountOfHandLuggage * 25.0;
        double price2 = amountOfLuggage * 55.0;

        Console.WriteLine();
        Console.WriteLine(" ---------------------------");
        Console.WriteLine($"{amountOfHandLuggage}x  | Hand Luggage |  € {price1},-");
        Console.WriteLine($"{amountOfLuggage}x  | Luggage      |  € {price2},-");
        Console.WriteLine("----------------------------");

        Console.WriteLine($"Total\t\t      € {totalCost},-");

        bool y = true;
        while (y)
        {
            Console.WriteLine();
            Console.WriteLine("Please confirm above check-in of luggage (Y/N)");
            string confirm = Console.ReadLine()!.ToUpper();

            if (confirm == "Y")
            {
                break;
            }
            else if (confirm == "N")
            {
                amountOfHandLuggage = 0;
                amountOfLuggage = 0;
                CostsAllLuggage();
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }
        // Y --> ga naar volgende stap (roep class/method aan)
    }
    public static void CheckInHandLuggage()
    {
        bool x = true;
        int handLuggage; ;

        while (x)
        {
            Console.WriteLine();
            Console.WriteLine("\x1B[4mCheck-in extra hand luggage\x1B[0m\nInsert the amount you want to check-in as {0}extra{1} hand luggage*", "\u001b[1m", "\u001b[0m");
            Console.WriteLine("* Note: Insert '1' if you are taking more than one hand luggage with you.\n  Else insert '0'.");


            if (int.TryParse(Console.ReadLine(), out handLuggage))
            {
                if (handLuggage == 0)
                {
                    x = false;
                }
                else if (handLuggage == 1)
                {
                    amountOfHandLuggage++;
                    x = false;
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
            else
            {
                Console.WriteLine("Invalid format");
            }
        }
    }

    public static void CheckInLuggage()
    {
        bool x = true;
        int luggage;

        while (x)
        {
            Console.WriteLine();
            Console.WriteLine("\x1B[4mCheck-in luggage\x1B[0m\nInsert the amount of luggage you want to check-in");

            if (int.TryParse(Console.ReadLine(), out luggage))
            {
                if (luggage == 0)
                {
                    x = false;
                }
                else if (luggage == 1)
                {
                    amountOfLuggage++;
                    x = false;
                }
                else if (luggage == 2)
                {
                    amountOfLuggage += 2;
                    x = false;
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
            else
            {
                Console.WriteLine("Invalid format");
            }
        }
    }
}