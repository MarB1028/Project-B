using System;
using ConsoleTables;

static class TicketOverview
{
    public static List<BookTicket> tickets;
    public static BookTicket ticket;

    public static void Ticket(List<BookTicket> tickets, bool payment)
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
            Console.WriteLine($"Flight:    {ticket1.Ticket.Flight.Airplane.Name} {ticket1.Ticket.Flight.BoardingDate} {ticket1.Ticket.Flight.Destination.City} {ticket1.Ticket.Flight.Destination.Airport}");
            Console.WriteLine($"Seat:      {ticket1.Ticket.Seat.SeatNumber}   Boarding gate: {ticket1.Ticket.Gate}");
            Console.WriteLine($"Booking Code: {CalculateTotalCosts.BookingCode}");
            Console.WriteLine("");
        }

        Console.WriteLine("-----------------------------------------------------------------");
        Console.WriteLine($"Total cost:");
        Console.WriteLine($"{ConfirmTicketInformation.GetPrice}");
        Console.WriteLine($"Booking Status:");
        Console.WriteLine($"{PaymentComplete(payment)}");
        Console.WriteLine("");    
        Console.WriteLine("\nPress any key to go back to main menu.");
        Console.ReadKey();
        Console.Clear();
        Menu.StartScreen();
    }


    public static string PaymentComplete(bool x) 
    {
        bool payment = false;
        if (payment is true)
        {
            return "Payment completed";
        }
        else
        {
            return "Payment not done";
        }
    }

}