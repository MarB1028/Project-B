using System.Collections.Generic;
using System.Net.Sockets;

static class ConfirmTicketInformation
{
    public static List<Passenger> AllPassengers = PassengerForm.passengers; //kopie maken van list in PassengerForm
    public static List<BookTicket> tickets;

    public static void PaymentScreen(List<BookTicket> tickets)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("STEP 5/5: Confirmation and Payment");
        Console.WriteLine("======================================================");
        Console.ResetColor();
        Console.WriteLine();

        DisplayTicketInformation(AllPassengers);

        CalculateTotalCosts.tickets = tickets;
        DisplayOverviewTotalCosts(tickets);

    }

    public static void DisplayTicketInformation(List<Passenger> passengers)
    {
        /* Persoonlijke gegevens worden al eerder gecheckt. Deze check is alleen ter bevestiging 
         * van het aantal vliegtickets en de totale prijs*/
        Console.WriteLine("Check the following information and confirm the\n total price to continue to payment");
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

    public static void DisplayOverviewTotalCosts(List<BookTicket> tickets)
    {
        double getPrice = CalculateTotalCosts.GetTotalPrice();
        double seatsprice = CalculateTotalCosts.seatsprice;

        Console.WriteLine("Total price including BTW/VAT");
        Console.WriteLine();
        Console.WriteLine(" --------------------------------");
        Console.WriteLine($"Total Tickets            |  € {seatsprice},-"); 
        Console.WriteLine($"Total Luggage            |  € {GetLugage.TotalCost},-");
        Console.WriteLine($"Total Catering           |  € {CateringLogic.TotalPrice},-");
        Console.WriteLine($"Standard Booking Costs   |  € 2,95,-"); // ?
        Console.WriteLine("---------------------------------");

        Console.WriteLine($"\t       Total  € {getPrice + 2.95}, -");

        Console.WriteLine();
        Console.WriteLine("Confirm the price above (Y/N)");
        string answer = Console.ReadLine()!.ToUpper();

        if (answer == "Y")
        {
            // Ga naar class MakePayment om betaling af te ronden
        }
        else
        {
            // ga terug naar menu scherm?
        }
    }
}