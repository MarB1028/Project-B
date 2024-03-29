﻿using System;
using System.Net.Sockets;
using System.Reflection.PortableExecutable;
using System.Security.Principal;
using ConsoleTables;

static class TicketOverview
{
    public static List<BookTicket> tickets;
    public static BookTicket ticket;

    public static void Ticket(List<BookTicket> tickets, bool payment)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("\t\t\t\t╔════════════════════════════════════════════════╗");
        Console.WriteLine("\t\t\t\t║                 AIRLINE TICKET                 ║");
        Console.WriteLine("\t\t\t\t╚════════════════════════════════════════════════╝");

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(new string('-', 120));

        foreach (var ticket1 in tickets)
        {
            Console.WriteLine($"{ticket1.Ticket.Seat.SeatType}");
            Console.WriteLine($"Ticket ID: {ticket1.TicketID}");
            Console.WriteLine($"Passenger: {ticket1.Ticket.Passenger.FirstName} {ticket1.Ticket.Passenger.LastName}");
            Console.WriteLine($"Flight:    {ticket1.Ticket.Flight.Airplane.Name} {ticket1.Ticket.Flight.BoardingDate} {ticket1.Ticket.Flight.Destination.City} {ticket1.Ticket.Flight.Destination.Airport}");
            Console.WriteLine($"Seat:      {ticket1.Ticket.Seat.SeatNumber}   Boarding gate: {ticket1.Ticket.Gate}");
            UpdateBookingscode();
            Console.WriteLine($"Booking Code: {CalculateTotalCosts.BookingCode}");
            Console.WriteLine("");
            ticket1.PaymentDone = payment;
        }

        Console.WriteLine(new string('-', 120));
        Console.WriteLine($"Total cost:");
        Console.WriteLine($"{ConfirmTicketInformation.GetPrice}");
        Console.WriteLine($"Booking Status:");
        Console.WriteLine($"{PaymentComplete(payment)}");
        Console.ResetColor();
        Console.WriteLine("");
        Console.WriteLine("\nPress any key to go back to main menu.");
        Console.ReadKey();
        Console.Clear();
        Menu.StartScreen();
    }


    public static string PaymentComplete(bool x)
    {
        if (x == true)
        {
            UpdatePaymentStatus(x);
            Console.ForegroundColor = ConsoleColor.Green;
            return "Payment completed";

        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            return "Payment not done";
        }

    }

    public static void UpdatePaymentStatus(bool y)
    {
        List<Account> accounts = SetGetAccounts.ReadAccountsFromJSON();

        foreach (Account account in accounts)
        {
            foreach (var boughtTicket in account.BoughtTickets)
            {
                if (y == true)
                {
                    boughtTicket.PaymentDone = true;
                    break;
                }
            }

            SetGetAccounts.WriteAccountToJSON(accounts);
            break;

        }
    }

    public static void UpdateBookingscode()
    {
        List<Account> accounts = SetGetAccounts.ReadAccountsFromJSON();

        foreach (Account account in accounts)
        {
            foreach (var boughtTicket in account.BoughtTickets)
            {
                CalculateTotalCosts.Bookingscode();
                boughtTicket.BookingsCode = CalculateTotalCosts.BookingCode;
            }

            SetGetAccounts.WriteAccountToJSON(accounts);
            break;

        }
    }

}