using System;
using ConsoleTables;

static class TicketOverview
{
    public static void Ticket(Flight flight, List<BookTicket> tickets, BookTicket ticket)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("╔════════════════════════════════════════════════╗");
        Console.WriteLine("║              AIRLINE TICKET                    ║");
        Console.WriteLine("╚════════════════════════════════════════════════╝");

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("-----------------------------------------------------------------");

        foreach (var ticket1 in tickets)
        {
            Console.WriteLine($"{ticket1.Ticket.Seat.SeatType}");
            Console.WriteLine($"Ticket ID: {ticket1.TicketID}");
            Console.WriteLine($"Passenger: {ticket1.Ticket.Passenger.Surname} {ticket1.Ticket.Passenger.Lastname}");
            Console.WriteLine($"Flight:    {flight.Airplane.Name} {flight.BoardingDate} {flight.Destination.City} {flight.Destination.Airport}");
            Console.WriteLine($"Seat:      {ticket1.Ticket.Seat.SeatNumber}   Boarding gate: {ticket1.Ticket.Gate}");
            Console.WriteLine($"Booking Code: {CalculateTotalCosts.BookingCode}");
            Console.WriteLine("");

             AddTicket(ticket1);
        }

        Console.WriteLine("-----------------------------------------------------------------");
        Console.WriteLine($"Total cost:");
        Console.WriteLine($"{CalculateTotalCosts.TotalCost}");
        Console.WriteLine($"Booking Status:");
        Console.WriteLine($"{PaymentComplete(ticket)}");
    }

    public static void ViewTicket(Flight flight, List<BookTicket> tickets, BookTicket ticket)
    {
        while (CheckLogin() == false)
        {
            Console.WriteLine();
            Console.WriteLine($"You are not logged in.\nPlease register or login to view your reservation");
            Console.WriteLine("Press 0 to go back");
            int FalseLogin = Convert.ToInt32(Console.ReadLine());
            if (FalseLogin == 0)
            {
                Console.WriteLine("You are now being redirected to the main page");
                Thread.Sleep(2500);
                Console.Clear();
                Menu.StartScreen();
            }
        }
        foreach (var ticket2 in tickets)
        {
            Console.WriteLine($"{ticket2.Ticket.Seat.SeatType}");
            Console.WriteLine($"Ticket ID: {ticket2.TicketID}");
            Console.WriteLine($"Passenger: {ticket2.Ticket.Passenger.Surname} {ticket2.Ticket.Passenger.Lastname}");
            Console.WriteLine($"Flight:    {flight.Airplane.Name} {flight.BoardingDate} {flight.Destination.City} {flight.Destination.Airport}");
            Console.WriteLine($"Seat:      {ticket2.Ticket.Seat.SeatNumber}   Boarding gate: {ticket2.Ticket.Gate}");
            Console.WriteLine($"Booking Code: {CalculateTotalCosts.BookingCode}");
            Console.WriteLine("");

        }

        Console.WriteLine("-----------------------------------------------------------------");
        Console.WriteLine($"Total cost:");
        Console.WriteLine($"{CalculateTotalCosts.TotalCost}");
        Console.WriteLine($"Booking Status:");
        Console.WriteLine($"{PaymentComplete(ticket)}");
    }
    public static string PaymentComplete(BookTicket ticket) // not completed (moet kijken naar betalingssysteem.
    {
        bool payment = false;
        if (payment is true)
        {
            ticket.PaymentDone= true;
            return "Payment completed";
        }
        else
        {
            ticket.PaymentDone= false;
            return "Payment not done";
        }
    }


    public static void AddTicket(BookTicket tickets) // schrijft de tickets naar account
    {
        List<Account> accounts = SetGetAccounts.ReadAccountsFromJSON();

        foreach (Account account in accounts)
        {
            if (account.LoggedIn == true)
            {
                account.BoughtTickets.Add(tickets);
            }
        }

        SetGetAccounts.WriteAccountToJSON(accounts);
    }

    public static bool CheckLogin() //checkt of user is ingelogd of niet
    {
        List<Account> accounts = SetGetAccounts.ReadAccountsFromJSON();

        foreach (Account account in accounts)
        {
            if (account.LoggedIn == true)
            {
                return true;
            }
        }
        return false;
    }
}