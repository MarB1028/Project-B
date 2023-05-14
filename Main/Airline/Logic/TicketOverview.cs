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


    public static void AddTicket(BookTicket ticket) // schrijft de tickets naar account
    {
        List<Account> accounts = SetGetAccounts.ReadAccountsFromJSON();

        foreach (Account account in accounts)
        {
            if (account.LoggedIn == true)
            {
                account.BoughtTickets.Add(ticket);
            }
        }

        SetGetAccounts.WriteAccountToJSON(accounts);
    }
}