using Newtonsoft.Json.Linq;
using System.Net.Sockets;
using System.Threading;

static class ViewBoughtTickets
{
    public static List<BookTicket> tickets;

    public static void ViewReservation()
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

        List<Account> accounts = SetGetAccounts.ReadAccountsFromJSON();
        Account loggedInAccount = null;

        foreach (Account account in accounts)
        {
            if (account.LoggedIn == true)
            {
                loggedInAccount = account;
                break;
            }
        }

        Console.WriteLine($"Reservation of {loggedInAccount.Email}:");
        Console.WriteLine($"Number of bought tickets: {loggedInAccount.BoughtTickets.Count}");
        Console.WriteLine("");

        if (loggedInAccount.BoughtTickets.Count == 0)
        {
            Console.WriteLine("You have not bought any tickets yet.");
        }
        else
        {
            foreach (var ticketObj in loggedInAccount.BoughtTickets)
            {
                var ticket = ((JObject)ticketObj)["Ticket"].ToObject<JObject>(); // Ticket objects halen
                var passenger = ticket["Passenger"].ToObject<JObject>(); // Passenger objects 
                var flight = ticket["Flight"].ToObject<JObject>(); // Flight objects
                var ticketID = (int)((JObject)ticketObj)["TicketID"]; // TicketID nummer halen uit de json

                Console.WriteLine($"{ticket["Seat"]["SeatType"]}");
                Console.WriteLine($"Ticket ID: {ticketID}");
                Console.WriteLine($"Name: {passenger["Surname"]} {passenger["Lastname"]}");
                Console.WriteLine($"Flight: {flight["Airplane"]["Name"]} - {flight["Destination"]["City"]}, {flight["Destination"]["Airport"]}");
                Console.WriteLine($"Seat: {ticket["Seat"]["SeatNumber"]}   Boarding gate: {ticket["Gate"]}");
                Console.WriteLine($"Booking Code: {CalculateTotalCosts.BookingCode}");
                Console.WriteLine("");
            }
            
        }
        Console.WriteLine("\nPress any key to go back to main menu.");
        Console.ReadKey();
        Console.Clear();
        Menu.StartScreen();
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