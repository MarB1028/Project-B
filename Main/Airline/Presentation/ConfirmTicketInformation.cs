static class ConfirmTicketInformation
{
    public static List<Passenger> AllPassengers = PassengerForm.passengers; //kopie maken van list in PassengerForm
    public static List<BookTicket> tickets;
    public static double GetPrice;

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
        GetPrice = CalculateTotalCosts.GetTotalPrice() + +2.95;
        double seatsprice = CalculateTotalCosts.seatsprice;

        Console.WriteLine("Total price including BTW/VAT");
        Console.WriteLine();
        Console.WriteLine(" --------------------------------");
        Console.WriteLine($"Total Tickets            |  € {seatsprice},-"); 
        Console.WriteLine($"Total Luggage            |  € {GetLugage.TotalCost},-");
        Console.WriteLine($"Total Catering           |  € {CateringLogic.TotalPrice},-");
        Console.WriteLine($"Standard Booking Costs   |  € 2,95,-"); // ?
        Console.WriteLine("---------------------------------");

        Console.WriteLine($"\t       Total  € {GetPrice}, -");

        Console.WriteLine();
        Console.WriteLine("Confirm the price above (Y/N)");
        string answer = Console.ReadLine()!.ToUpper();

        if (answer == "Y")
        {
            MakePayment();
        }
        else
        {
            // Verwijder persoonlijke gegevens uit json file en maak de ticket(s) weer beschikbaar!
            Menu.StartScreen();
        }
    }

    public static double MakePayment()
    {
        Console.WriteLine();
        Console.WriteLine("Would you like to pay the whole price upfront?\n\nY: I would like to pay the whole price upfront\nN: I would like to pay in 2 terms");
        string answer = Console.ReadLine()!.ToUpper();

        Console.WriteLine();
        Console.WriteLine("Redirected to payment screen");
        Thread.Sleep(1000);
        Console.Clear();

        try
        {
            if (answer == "Y")
            {
                try
                {
                    Console.WriteLine($"Price to pay: {GetPrice}");
                    Console.WriteLine();
                    Console.WriteLine("payment options: (1) Ideaal\n(2) PayPal\n(3) Master Card\n(4) Visa");
                    int paymentType = Convert.ToInt32(Console.ReadLine()!);

                    if (paymentType == 1)
                    {
                    }
                    else if (paymentType == 2)
                    {
                    }
                    else if (paymentType == 3)
                    {

                    }
                    else if (paymentType == 4)
                    {

                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid format!");
                }
            }
            else if (answer == "N") // betaal in 2 termijnen
            {
                double pricePerTerm = GetPrice / 2.0;
                Console.WriteLine($"Price to pay for term 1*: {pricePerTerm}");
                Console.WriteLine($"*The next payment needs to be made no later than 12 hours before the flight.");
                Console.WriteLine();
                Console.WriteLine("payment options: (1) Ideaal\n(2) PayPal\n(3) Master Card\n(4) Visa");
                int paymentType = Convert.ToInt32(Console.ReadLine()!);

            }
        }
        catch
        {
            Console.WriteLine("Invalid input!");
        }
        return GetPrice;
    }  

    public static void MakePaymentLastTerm()
    {
        double remainingPrice = MakePayment() / 2.0;
        Console.WriteLine(remainingPrice);

    }
}