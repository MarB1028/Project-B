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
        DisplayOverviewTotalCosts();

    }

    public static void DisplayTicketInformation(List<Passenger> passengers)
    {
        /* Persoonlijke gegevens worden al eerder gecheckt. Deze check is alleen ter bevestiging 
         * van het aantal vliegtickets en de totale prijs*/
        Console.WriteLine("Check the following information and confirm the\ntotal price to continue to payment");
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
        GetPrice = CalculateTotalCosts.GetTotalPrice() + +2.95;
        double seatsprice = CalculateTotalCosts.seatsprice;

        Console.WriteLine("Total price including BTW/VAT");
        Console.WriteLine(" --------------------------------");
        Console.WriteLine($"Total Tickets            |  € {seatsprice},-"); 
        Console.WriteLine($"Total Luggage            |  € {GetLugage.TotalCost},-");
        Console.WriteLine($"Total Catering           |  € {CateringLogic.TotalPrice},-");
        Console.WriteLine($"Standard Booking Costs   |  € 2,95,-"); 
        Console.WriteLine("---------------------------------");

        Console.WriteLine($"\t       Total  € {GetPrice}, -");

        Console.WriteLine();
        Console.WriteLine("Confirm the price above (Y/N)");
        string answer = Console.ReadLine()!.ToUpper();

        bool x = true;
        while (x)
        {
            if (answer == "Y")
            {
                MakePayment();
                x = false;
            }
            else if (answer == "N")
            {
                // Verwijder persoonlijke gegevens uit json file en maak de ticket(s) weer beschikbaar!
                Menu.StartScreen();
                x = false;
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }
        }
        // Ticket overview of terug naar het menu?
    }

    public static bool MakePayment()
    {
        Console.WriteLine();
        Console.WriteLine("Would you like to pay the whole price upfront?\nY: I would like to pay the whole price upfront\nN: I would like to pay in 2 terms");
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
                    Console.WriteLine("payment options:\n(1) Ideaal\n(2) PayPal\n(3) Master Card\n(4) Visa");
                    int paymentType = Convert.ToInt32(Console.ReadLine()!);

                    if (paymentType == 1)
                    {
                        bool x = true;
                        while (x)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Confirm payment by Ideaal (Y/N)");
                            string confirmPayment = Console.ReadLine()!.ToUpper();

                            if (confirmPayment == "Y")
                            {
                                Console.WriteLine("Payment complete!");
                                Console.WriteLine("You ticket(s) will be added to your account shortly");
                                Console.WriteLine("Check your reservation in your account");
                                x = false;
                                return true;

                            }
                            else if (confirmPayment == "N")
                            {
                                Console.WriteLine("Payment cancelled!");
                                Console.WriteLine("Try again");
                                MakePayment();
                                x = false;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input!");
                            }
                        }
                    }
                    else if (paymentType == 2)
                    {
                        bool x = true;
                        while (x)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Confirm payment by PayPal (Y/N)");
                            string confirmPayment = Console.ReadLine()!.ToUpper();

                            if (confirmPayment == "Y")
                            {
                                Console.WriteLine("Payment complete!");
                                Console.WriteLine("You ticket(s) will be added to your account shortly");
                                Console.WriteLine("Check your reservation in your account");
                                x = false;
                                return true;

                            }
                            else if (confirmPayment == "N")
                            {
                                Console.WriteLine("Payment cancelled!");
                                Console.WriteLine("Try again");
                                MakePayment();
                                x = false;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input!");
                            }
                        }
                    }
                    else if (paymentType == 3)
                    {
                        bool x = true;
                        while (x)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Confirm payment by Master Card (Y/N)");
                            string confirmPayment = Console.ReadLine()!.ToUpper();

                            if (confirmPayment == "Y")
                            {
                                Console.WriteLine("Payment complete!");
                                Console.WriteLine("You ticket(s) will be added to your account shortly");
                                Console.WriteLine("Check your reservation in your account");
                                x = false;
                                return true;

                            }
                            else if (confirmPayment == "N")
                            {
                                Console.WriteLine("Payment cancelled!");
                                Console.WriteLine("Try again");
                                MakePayment();
                                x = false;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input!");
                            }
                        }
                    }
                    else if (paymentType == 4)
                    {
                        bool x = true;
                        while (x)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Confirm payment by Visa (Y/N)");
                            string confirmPayment = Console.ReadLine()!.ToUpper();

                            if (confirmPayment == "Y")
                            {
                                Console.WriteLine("Payment complete!");
                                Console.WriteLine("You ticket(s) will be added to your account shortly");
                                Console.WriteLine("Check your reservation in your account");
                                x = false;
                                return true;

                            }
                            else if (confirmPayment == "N")
                            {
                                Console.WriteLine("Payment cancelled!");
                                Console.WriteLine("Try again");
                                MakePayment();
                                x = false;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input!");
                            }
                        }
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
                try
                {
                    double pricePerTerm = GetPrice / 2.0;

                    Console.WriteLine($"Price to pay for term 1*: {pricePerTerm}");
                    Console.WriteLine($"*The next payment needs to be made no later than 12 hours before the flight.");

                    Console.WriteLine();
                    Console.WriteLine("payment options: (1) Ideaal\n(2) PayPal\n(3) Master Card\n(4) Visa");
                    int paymentType = Convert.ToInt32(Console.ReadLine()!);

                    if (paymentType == 1)
                    {
                        bool x = true;
                        while (x)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Confirm payment by Ideaal (Y/N)");
                            string confirmPayment = Console.ReadLine()!.ToUpper();

                            if (confirmPayment == "Y")
                            {
                                Console.WriteLine("Payment 1/2 complete!");
                                Console.WriteLine("You ticket(s) will be added to your account after the second payment");
                                Console.WriteLine("is complete. Pay remaining costs to 12 hours before your flight!");
                                x = false;
                                return true;

                            }
                            else if (confirmPayment == "N")
                            {
                                Console.WriteLine("Payment cancelled!");
                                Console.WriteLine("Try again");
                                MakePayment();
                                x = false;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input!");
                            }
                        }
                    }
                    else if (paymentType == 2)
                    {
                        bool x = true;
                        while (x)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Confirm payment by Paypal (Y/N)");
                            string confirmPayment = Console.ReadLine()!.ToUpper();

                            if (confirmPayment == "Y")
                            {
                                Console.WriteLine("Payment 1/2 complete!");
                                Console.WriteLine("You ticket(s) will be added to your account after the second payment");
                                Console.WriteLine("is complete. Pay remaining costs to 12 hours before your flight!");
                                x = false;
                                return true;

                            }
                            else if (confirmPayment == "N")
                            {
                                Console.WriteLine("Payment cancelled!");
                                Console.WriteLine("Try again");
                                MakePayment();
                                x = false;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input!");
                            }
                        }
                    }
                    else if (paymentType == 3)
                    {
                        bool x = true;
                        while (x)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Confirm payment by Master Card (Y/N)");
                            string confirmPayment = Console.ReadLine()!.ToUpper();

                            if (confirmPayment == "Y")
                            {
                                Console.WriteLine("Payment 1/2 complete!");
                                Console.WriteLine("You ticket(s) will be added to your account after the second payment");
                                Console.WriteLine("is complete. Pay remaining costs to 12 hours before your flight!");
                                x = false;
                                return true;

                            }
                            else if (confirmPayment == "N")
                            {
                                Console.WriteLine("Payment cancelled!");
                                Console.WriteLine("Try again");
                                MakePayment();
                                x = false;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input!");
                            }
                        }
                    }
                    else if (paymentType == 4)
                    {
                        bool x = true;
                        while (x)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Confirm payment by Visa (Y/N)");
                            string confirmPayment = Console.ReadLine()!.ToUpper();

                            if (confirmPayment == "Y")
                            {
                                Console.WriteLine("Payment 1/2 complete!");
                                Console.WriteLine("You ticket(s) will be added to your account after the second payment");
                                Console.WriteLine("is complete. Pay remaining costs to 12 hours before your flight!");
                                x = false;
                                return true;

                            }
                            else if (confirmPayment == "N")
                            {
                                Console.WriteLine("Payment cancelled!");
                                Console.WriteLine("Try again");
                                MakePayment();
                                x = false;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input!");
                            }
                        }
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
        }
        catch
        {
            Console.WriteLine("Invalid input!");
        }
        return false;
    }  

    public static bool MakePaymentLastTerm()
    {
        double remainingPrice = GetPrice / 2.0;

        Console.Clear();
        Console.WriteLine("Would you like to pay term 2/2 to receive your ticket(s)? Y/N");
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
                    Console.WriteLine($"Price to pay: {remainingPrice}");
                    Console.WriteLine();
                    Console.WriteLine("payment options:\n(1) Ideaal\n(2) PayPal\n(3) Master Card\n(4) Visa");
                    int paymentType = Convert.ToInt32(Console.ReadLine()!);

                    if (paymentType == 1)
                    {
                        bool x = true;
                        while (x)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Confirm payment by Ideaal (Y/N)");
                            string confirmPayment = Console.ReadLine()!.ToUpper();

                            if (confirmPayment == "Y")
                            {
                                Console.WriteLine("Payment complete!");
                                Console.WriteLine("You ticket(s) will be added to your account shortly");
                                Console.WriteLine("Check your reservation in your account");
                                x = false;
                                return true;

                            }
                            else if (confirmPayment == "N")
                            {
                                Console.WriteLine("Payment cancelled!");
                                Console.WriteLine("Try again");
                                MakePayment();
                                x = false;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input!");
                            }
                        }
                    }
                    else if (paymentType == 2)
                    {
                        bool x = true;
                        while (x)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Confirm payment by PayPal (Y/N)");
                            string confirmPayment = Console.ReadLine()!.ToUpper();

                            if (confirmPayment == "Y")
                            {
                                Console.WriteLine("Payment complete!");
                                Console.WriteLine("You ticket(s) will be added to your account shortly");
                                Console.WriteLine("Check your reservation in your account");
                                x = false;
                                return true;

                            }
                            else if (confirmPayment == "N")
                            {
                                Console.WriteLine("Payment cancelled!");
                                Console.WriteLine("Try again");
                                MakePayment();
                                x = false;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input!");
                            }
                        }
                    }
                    else if (paymentType == 3)
                    {
                        bool x = true;
                        while (x)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Confirm payment by Master Card (Y/N)");
                            string confirmPayment = Console.ReadLine()!.ToUpper();

                            if (confirmPayment == "Y")
                            {
                                Console.WriteLine("Payment complete!");
                                Console.WriteLine("You ticket(s) will be added to your account shortly");
                                Console.WriteLine("Check your reservation in your account");
                                x = false;
                                return true;

                            }
                            else if (confirmPayment == "N")
                            {
                                Console.WriteLine("Payment cancelled!");
                                Console.WriteLine("Try again");
                                MakePayment();
                                x = false;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input!");
                            }
                        }
                    }
                    else if (paymentType == 4)
                    {
                        bool x = true;
                        while (x)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Confirm payment by Visa (Y/N)");
                            string confirmPayment = Console.ReadLine()!.ToUpper();

                            if (confirmPayment == "Y")
                            {
                                Console.WriteLine("Payment complete!");
                                Console.WriteLine("You ticket(s) will be added to your account shortly");
                                Console.WriteLine("Check your reservation in your account");
                                x = false;
                                return true;

                            }
                            else if (confirmPayment == "N")
                            {
                                Console.WriteLine("Payment cancelled!");
                                Console.WriteLine("Try again");
                                MakePayment();
                                x = false;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input!");
                            }
                        }
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
            else if (answer == "N") 
            {
                Console.WriteLine("Note: You have until 12 hours before your flight to pay the remaining term");
                Console.Clear();
                Menu.StartScreen(); // terug naar het menu
            }
        }
        catch
        {
            Console.WriteLine("Invalid input!");
        }
        return false;
    }
}