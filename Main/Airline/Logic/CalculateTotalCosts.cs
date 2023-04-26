﻿static class CalculateTotalCosts
{
    public static List<BookTicket> tickets = new List<BookTicket>();
    public static int amountOfLuggage;
    public static int amountOfHandLuggage;
    public static double TotalCost;

    public static double GetTotalPrice()
    {
        foreach (BookTicket ticket in tickets)
        {
            TotalCost = TotalCost + GetSeatPrice(ticket);
        }
        return TotalCost;
    }

    public static double GetSeatPrice(BookTicket ticket)
    {
        Passenger passenger = ticket.Ticket.Passenger;
        int age = DateTime.Today.Year - passenger.BirthDate.Year;
        switch (age)
        {
            case >= 0 and <= 3:
                return 0 * ticket.Ticket.Seat.Price;
            case >= 4 and <= 12:
                return 0.35 * ticket.Ticket.Seat.Price;
            case >= 13 and <= 17:
                return 0.65 * ticket.Ticket.Seat.Price;
            case >= 18:
                return 1 * ticket.Ticket.Seat.Price;
            default:
                return 0;
        }
    }

    public static void CostsAllLuggage()
    {
        CheckInHandLuggage();
        CheckInLuggage();

        double price1;
        double totalCost;
        double price2 = amountOfLuggage * 55.0;
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
        Flight flight = null;
        foreach (BookTicket ticket in tickets)
        {
            flight = ticket.Ticket.Flight;
        }
        CateringForm.Catering(flight);
        // Y --> ga naar volgende stap (roep class/method aan)
    }
    public static void CheckInHandLuggage()
    {
        bool x = true;
        int handLuggage;

        while (x)
        {
            Console.WriteLine();
            Console.WriteLine("\x1B[4mCheck-in hand luggage\x1B[0m\nInsert the total amount of hand luggage you want to check-in", "\u001b[1m", "\u001b[0m");
            int amountOfTickets = tickets.Count();


            if (int.TryParse(Console.ReadLine(), out handLuggage))
            {
                if (handLuggage == 0)
                {
                    x = false;
                }
                else if (handLuggage <= (amountOfTickets * 2))
                {
                    amountOfHandLuggage += handLuggage;
                    x = false;
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
            Console.WriteLine("\x1B[4mCheck-in luggage\x1B[0m\nInsert the total amount of luggage you want to check-in");
            int amountOfTickets = tickets.Count();

            if (int.TryParse(Console.ReadLine(), out luggage))
            {
                if (luggage == 0)
                {
                    x = false;
                }
                else if (luggage <= (amountOfTickets * 2))
                {
                    amountOfLuggage += luggage;
                    x = false;
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
                Console.WriteLine("Invalid format");
            }
        }
    }
}