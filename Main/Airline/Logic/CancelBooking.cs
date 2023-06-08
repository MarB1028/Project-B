public static class CancelBooking
{

    public static void BookingCancel(List<BookTicket> tickets)
    {
        int cancellation;

        bool x = true;
        while (x)
        {
            Console.WriteLine("Are you sure you would like to cancel the booking?");
            Console.WriteLine("1. Yes\n2. No");
            Console.Write("> ");
            string cancellation0 = Console.ReadLine();
            while (int.TryParse(cancellation0, out cancellation) == false && cancellation0 != "1" && cancellation0 != "2")
            {
                Console.WriteLine("Please enter a valid input.");
                Console.WriteLine("Are you sure you would like to cancel the booking?");
                Console.WriteLine("1. Yes\n2. No");
                Console.Write("> ");
                cancellation0 = Console.ReadLine();
            }

            if (cancellation == 1)
            {
                foreach (BookTicket ticket in tickets)
                {
                    ticket.Booked = false;
                    ticket.Ticket.Passenger = null;
                    DataTickets.WriteTicketToJson(ticket.Ticket.Flight, ticket);
                }

                Console.WriteLine("You are now being redirected back to the main page");
                Console.Clear();
                Menu.StartScreen();
                x = false;
            }
            else if (cancellation == 2)
            {
                Console.WriteLine("You are being redirected back to the last step");
                Console.Clear();
                ConfirmTicketInformation.PaymentScreen();
                break;
            }
            else
            {
                Console.WriteLine("Invalid Input");
                BookingCancel(tickets);
            }
        }
    }
}
