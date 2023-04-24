static class Menu
{
    public static void StartScreen()
    {
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
        Console.WriteLine("4. Exit");
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
                    Console.Clear();
                    StartScreen();
                    break;

                case "4":
                    // Exit 
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice.\nPlease enter a valid choice (1 to 4)");
                    Thread.Sleep(2000);
                    Console.Clear();
                    StartScreen();
                    choice = Console.ReadLine();
                    break;
            }
        }
    }
}