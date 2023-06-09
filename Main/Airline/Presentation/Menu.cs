static class Menu
{
    public static void StartScreen()
    {
        //Logo
        Console.WriteLine("\n");
        Console.WriteLine("       __|__");
        Console.WriteLine("--------(_)--------");
        Console.WriteLine("  O  O       O  O");
        Console.WriteLine(" Rotterdam Airlines");
        Console.WriteLine("\n");

        
        // start screen
        Console.WriteLine("\nWelcome to Rotterdam Airlines Reservation System!");
        Console.WriteLine("===============================================");
        Console.WriteLine("Please select an option:");
        Console.WriteLine("1. Log In / Register");
        Console.WriteLine("2. Search Flights");
        Console.WriteLine("3. View Reservation");
        Console.WriteLine("4. View Vouchers");
        Console.WriteLine("5. Cancel Ticket(s)");
        Console.WriteLine("6. Log Out");
        Console.WriteLine("7. Exit");
        Console.WriteLine("===============================================");

        // user input
        Console.WriteLine("Please enter your choice.");
        Console.Write("> ");
        string choice = Console.ReadLine();
        Console.Clear();

        // Switch cases
        bool x = true;
        while (x == true)
        {
            switch (choice)
            {
                case "1":
                    Login.LoginChecker();
                    x = false;
                    // als user is ingelogd -> melding al ingelogd (volgende sprint oppakken)
                    break;
                case "2":
                    FlightHeader.Header();
                    x = false;
                    break;
                case "3":
                    ViewBoughtTickets.ViewReservation();
                    Console.Clear();
                    
                    StartScreen();
                    break;
                case "4":
                    ViewVouchers.Info();
                    Console.Clear();
                    
                    StartScreen();
                    break;
                case "5":
                    CancelTickets.Canceltickets();
                    break;
                case "6":
                    LogoutFunc.LogOut();
                    break;
                case "7":
                    LogoutFunc.LoggingOut();
                    Console.WriteLine("Thank you for visiting our site.\nHopefully we see you again.");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice.\nPlease enter a valid choice (1 to 5)");
                    Thread.Sleep(2000);
                    Console.Clear();
                    StartScreen();
                    choice = Console.ReadLine();
                    break;
            }
        }
    }
}