static class CancelTickets
{
    public static Account Account;
    public static List<BookTicket> futuretickets = new List<BookTicket>();
    public static void Canceltickets() {
        if (CheckLogin() == false) {
            Console.WriteLine("You are not logged in yet, go back!");
            Menu.StartScreen();
        }
        GetTickets();                           
        foreach (BookTicket bookticket in futuretickets) {      //TODO: hier moet ook een kleine review van de tickets weergegeven worden
            Console.WriteLine(bookticket.TicketID.ToString(), bookticket.Ticket.Passenger);
        }
        bool x = true;
        BookTicket ticket = null;
        while (x) {
            Console.WriteLine("Enter the ticket ID of the ticket you want to cancel");
            int ans = Convert.ToInt32(Console.ReadLine());

            foreach (BookTicket bookticket in futuretickets) {
                if (ans == bookticket.TicketID) {
                    ticket = bookticket;
                    break;
                }
                else {
                    Console.WriteLine("That ID does not exist. try again");
                }
            }
        }
            int timedif = (ticket.Ticket.Flight.BoardingDate - DateTime.Now).Hours;
            if (ticket.Ticket.Flight.Destination.FlightDuration > 1.5) {
                if (timedif > 4) {
                    RemoveTicket(ticket);
                }
                else {
                    Console.WriteLine("Unfortunately it's to late to cancel this ticket!");
                }
            }
            else {
                if (timedif > 3) {
                    RemoveTicket(ticket);
                }
                else {
                    Console.WriteLine("Unfortunately it's to late to cancel this ticket!");
                }
            }
    }

    public static void RemoveTicket(BookTicket ticket) {
        Console.WriteLine("Are you sure that you want to cancel this ticket? Y/N");
        string ans = Console.ReadLine().ToUpper();
        if (ans == "Y") {
            foreach (BookTicket bookticket in Account.BoughtTickets) {
                if (bookticket == ticket) {
                                Account.BoughtTickets.Remove(bookticket);
                }
            }
            ticket.Booked = false;
            ticket.Ticket.Passenger = null;
            DataTickets.WriteTicketToJson(ticket.Ticket.Flight, ticket);
        }
        else if (ans == "N") {
            Canceltickets();
        }
        else {
            Console.WriteLine("Please enter Y or N.");
            RemoveTicket(ticket);
        }
        
    }

    public static void GetTickets() {
        
        if (Account.BoughtTickets == null) {
            Console.WriteLine("You haven't bought any tickets yet to cancel.");
        }
        foreach (BookTicket ticket in Account.BoughtTickets) {
            if (ticket.Ticket.Flight.Destination.Status == "On schedule" || ticket.Ticket.Flight.Destination.Status == "Full") {
                futuretickets.Add(ticket);
            }
        }
        //Hier check je of er tickets gekocht zijn voor in de toekomst
        if (futuretickets == null) {
            Console.WriteLine("You haven't bought any tickets in the future, so there is nothing to cancel!");
            Menu.StartScreen();
        }
    }

    public static bool CheckLogin() //checkt of user is ingelogd of niet
    {
        List<Account> accounts = SetGetAccounts.ReadAccountsFromJSON();

        foreach (Account account in accounts)
        {
            if (account.LoggedIn == true)
            {
                Account = account;
                return true;
            }
        }
        return false;
    }
}