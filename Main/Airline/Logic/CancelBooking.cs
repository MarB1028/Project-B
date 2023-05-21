public static class CancelBooking
{

    public static void BookingCancel(List<BookTicket> tickets)
    {
        bool x = true;
        while (x)
        {
            Console.WriteLine("Are you sure you would like to cancel the booking?");
            Console.WriteLine("1. Yes\n2. No");
            int cancellation = Convert.ToInt32(Console.ReadLine());

            if (cancellation == 1)
            {
                foreach (BookTicket ticket in tickets)
                {
                    ticket.Booked = false;
                    ticket.Ticket.Passenger = null;
                    DataTickets.WriteTicketToJson(ticket.Ticket.Flight, ticket);
                }

                Console.WriteLine("You are now being redirected back to the main page");
                Menu.StartScreen();
                x = false;
            }
            else if (cancellation == 2)
            {
                Console.WriteLine("You are being redirected back to the last step");
                ConfirmTicketInformation.PaymentScreen();
                break;
            }
            else
            {
                Console.WriteLine("Please insert 1 or 2.");
                cancellation = Convert.ToInt32(Console.ReadLine());
            }
        }
    }
}
