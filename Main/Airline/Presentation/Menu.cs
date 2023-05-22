static class Menu
{
    public static void StartScreen()
    {
        //Logo
        Console.WriteLine("  ____       _   _               _                      _    _      _ _                 ");
        Console.WriteLine(" |  _ \\ ___ | |_| |_ ___ _ __ __| | __ _ _ __ ___      / \\  (_)_ __| (_)_ __   ___  ___ ");
        Console.WriteLine(" | |_) / _ \\| __| __/ _ \\ '__/ _` |/ _` | '_ ` _ \\    / _ \\ | | '__| | | '_ \\ / _ \\/ __|          __|__");
        Console.WriteLine(" |  _ < (_) | |_| ||  __/ | | (_| | (_| | | | | | |  / ___ \\| | |  | | | | | |  __/\\__ \\   --------(_)--------");
        Console.WriteLine(" |_| \\_\\___/ \\__|\\__\\___|_|  \\__,_|\\__,_|_| |_| |_| /_/   \\_\\_|_|  |_|_|_| |_|\\___||___/     O  O       O  O");
        Console.WriteLine();
        Console.WriteLine("\n");
        Console.WriteLine("\n");
        Console.WriteLine("       __|__");
        Console.WriteLine("--------(_)--------");
        Console.WriteLine("  O  O       O  O");
        Console.WriteLine(" Rotterdam Airlines");
        Console.WriteLine("\n");

        
    


        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("STEP 1/5: Entry point of the program.");
        Console.WriteLine("===============================================");
        Console.ResetColor();

        // start screen
        Console.WriteLine("\nWelcome to Rotterdam Airlines Reservation System!");
        Console.WriteLine("===============================================");
        Console.WriteLine("Please select an option:");
        Console.WriteLine("1. Log In / Register");
        Console.WriteLine("2. Search Flights");
        Console.WriteLine("3. View Reservation");
        Console.WriteLine("4. Cancel Ticket(s)");
        Console.WriteLine("5. Exit");
        Console.WriteLine("===============================================");

        // user input
        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine();
        Console.Clear();

        // Switch cases
        bool x = true;
        while (x == true)
        {
            switch (choice)
            {
                case "1":
                    Login.LoginpageMessage();
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
                    CancelTickets.Canceltickets();
                    break;
                case "5":
                    Console.WriteLine("Thank you for visiting our site.\nHopefully we see you again.");
                    // Exit 
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