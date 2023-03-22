using System.Collections.Generic;

class Menu
{
    public void StartScreen()
    {
        // start screen
        Console.WriteLine("Welcome to Rotterdam Airlines Reservation System!");
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
        switch (choice)
        {
            case "1":

                break;
            case "2":
                OverviewFlights overview = new OverviewFlights();
                overview.ShowAvailableFlights();
                break;
            case "3":
                break;

            case "4":
                // Exit 
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }
}
