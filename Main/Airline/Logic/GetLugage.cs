public static class GetLugage
{
    public static List<BookTicket> tickets;
    public static int amountOfLuggage;
    public static int amountOfHandLuggage;
    public static double TotalCost;
    public static double price1;
    public static double price2;
    public static double totalCost;

    public static int CheckInHandLuggage()
    {
        bool x = true;
        int handLuggage;

        while (x)
        {
            Console.WriteLine();
            Console.WriteLine("\x1B[4mCheck-in hand luggage\x1B[0m\nInsert the total amount of hand luggage you want to check-in", "\u001b[1m", "\u001b[0m");
            Console.Write("> ");
            int amountOfTickets = tickets.Count();


            if (int.TryParse(Console.ReadLine(), out handLuggage))
            {
                if (handLuggage == 0)
                {
                    CheckInLuggage(0);
                    x = false;
                }
                else if (handLuggage <= (amountOfTickets * 2))
                {
                    if (handLuggage >= 1)
                    {
                        amountOfHandLuggage += handLuggage;
                        CheckInLuggage(amountOfHandLuggage);
                        x = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input! Amount of hand luggage cannot be negative.");
                    }
                }
                else if (handLuggage > (amountOfTickets * 2))
                {
                    Console.WriteLine("You exceeded the maximim amount of hand luggage allowed per person");
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
            else
            {
                Console.WriteLine("Invalid format!");
            }
        }
        return 0;
    }

    public static int CheckInLuggage(int amountOfHandLuggage)
    {
        bool x = true;
        int luggage;

        while (x)
        {
            Console.WriteLine();
            Console.WriteLine("\x1B[4mCheck-in luggage\x1B[0m\nInsert the total amount of luggage you want to check-in");
            Console.Write("> ");
            int amountOfTickets = tickets.Count();

            if (int.TryParse(Console.ReadLine(), out luggage))
            {
                if (luggage == 0)
                {
                    ConfirmPrice();
                    x = false;
                }
                else if (luggage <= (amountOfTickets * 2))
                {
                    if (luggage >= 1)
                    {
                        amountOfLuggage += luggage;
                        ConfirmPrice();
                        x = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input! Amount of luggage cannot be negative.");
                    }
                }
                else if (luggage > (amountOfTickets * 2))
                {
                    Console.WriteLine("You exceeded the maximim amount of luggage allowed per person");
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
            else
            {
                Console.WriteLine("Invalid format!");
            }
        }
        return 0;
    }

    public static void CostsAllLuggage(int amountOfHandLuggage, int amountOfLuggage)
    {
        price2 = amountOfLuggage * 55.0;
        int amountOfTickets = tickets.Count();

        if (amountOfHandLuggage <= amountOfTickets)
        {
            price1 = 0.0;
            totalCost = amountOfLuggage * 55.0;
        }
        else
        {
            price1 = (amountOfHandLuggage - amountOfTickets) * 25.0;
            totalCost = (amountOfHandLuggage - amountOfTickets) * 25.0 + amountOfLuggage * 55.0;
        }

        TotalCost = totalCost;
    }

    public static void ConfirmPrice()
    {
        CostsAllLuggage(amountOfHandLuggage, amountOfLuggage);

        Console.WriteLine();
        Console.WriteLine(" ---------------------------");
        Console.WriteLine($"{amountOfHandLuggage}x  | Hand Luggage |  € {price1},-");
        Console.WriteLine($"{amountOfLuggage}x  | Luggage      |  € {price2},-");
        Console.WriteLine("----------------------------");

        Console.WriteLine($"\t       Total  € {totalCost},-");

        bool y = true;
        while (y)
        {
            Console.WriteLine();
            Console.WriteLine($"Please confirm above check-in of luggage\n1.Yes\n2.No");
            Console.Write("> ");
            string confirm = Console.ReadLine()!.ToUpper();

            if (confirm == "1")
            {
                amountOfHandLuggage = 0;
                amountOfLuggage = 0;
                y = false;
            }
            else if (confirm == "2")
            {
                amountOfHandLuggage = 0;
                amountOfLuggage = 0;
                CheckInHandLuggage();
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }

        Flight flight = null;
        foreach (BookTicket ticket in tickets)
        {
            flight = ticket.Ticket.Flight;
        }

        Console.WriteLine();
        Console.Write("Press ENTER to continue...");
        Console.ReadLine();
        Console.Clear();

        CateringForm.Catering(flight, tickets);
    }
}
