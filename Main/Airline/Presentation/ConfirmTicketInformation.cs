static class ConfirmTicketInformation
{
    public static List<Passenger> AllPassengers = PassengerForm.passengers; //kopie maken van list in PassengerForm
    public static void PaymentScreen()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("STEP 5/5: Confirmation and Payment");
        Console.WriteLine("======================================================");
        Console.ResetColor();
        Console.WriteLine();
        DisplayTicketInformation(AllPassengers);
    }
    public static void DisplayTicketInformation(List<Passenger> passengers)
    {
        /* Persoonlijke gegevens worden al eerder gecheckt. Deze check is alleen ter bevestiging 
         * van het aantal vliegtickets en de totale prijs*/
        Console.WriteLine("Check the following information and confirm the total price\nto continue to payment");
        Console.WriteLine();

        int passengersAmount = 1;

        foreach (Passenger passenger in passengers)
        {
            Console.WriteLine($"Passenger {passengersAmount}");
            Console.WriteLine();
            Console.WriteLine($"Surname: {passenger.Surname}\nLast Name: {passenger.Lastname}\nSex: {passenger.Sex}");
            Console.WriteLine($"Birth Date: {passenger.BirthDate}\nAdress: {passenger.Adress}\nPhone Number: {passenger.PhoneNumber}");
            Console.WriteLine();

            passengersAmount++;
        }
    }

    public static void DisplayOverviewTotalCosts()
    {
        // Wordt in class calculatetotalcosts al alles bij elkaar opgeteld?
        // Deze hier aanroepen

        Console.Clear();
        Console.WriteLine("Total price including BTW/VAT");
        Console.WriteLine();
        Console.WriteLine(" ---------------------------");
        Console.WriteLine($"Total Tickets            |  € ,-");
        Console.WriteLine($"Total Luggage            |  € ,-");
        Console.WriteLine($"Total Catering           |  € ,-");
        Console.WriteLine($"Standard Booking Costs   |  € 2,95,-"); // ?
        Console.WriteLine("----------------------------");

        Console.WriteLine($"\t       Total  € ,-");

        // Klopt de prijs? Nee? terug naar stoelen boeken?
        // Ja? Ga naar class MakePayment
    }
}