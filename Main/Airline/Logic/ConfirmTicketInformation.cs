static class ConfirmTicketInformation
{
    public static List<Passenger> AllPassengers = PassengerForm.passengers; //kopie maken van list in PassengerForm
    public static List<BookTicket> Tickets;
    public static double GetPrice;
    public static bool payment;

    public static void PaymentScreen()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("STEP 5/5: Confirmation and Payment");
        Console.WriteLine("======================================================");
        Console.ResetColor();
        Console.WriteLine();

        DisplayTicketInformation();

        CalculateTotalCosts.tickets = Tickets;
        DisplayOverviewTotalCosts();

    }

    public static void DisplayTicketInformation()
    {
        /* Persoonlijke gegevens worden al eerder gecheckt. Deze check is alleen ter bevestiging 
         * van het aantal vliegtickets en de totale prijs*/
        Console.WriteLine("Check the following information and confirm the\ntotal price to continue to payment.");
        Console.WriteLine();
        
        int count = 1;
        foreach (BookTicket ticket in Tickets)
        {
            Console.WriteLine($"Passenger {count}.");
            Console.WriteLine();
            Console.WriteLine($"First name: {ticket.Ticket.Passenger.FirstName}\nSurname: {ticket.Ticket.Passenger.LastName}\nSex: {ticket.Ticket.Passenger.Sex}");
            Console.WriteLine($"Birth date: {ticket.Ticket.Passenger.BirthDate}\nAddress: {ticket.Ticket.Passenger.Address}\nPhone number: {ticket.Ticket.Passenger.PhoneNumber}");
            Console.WriteLine();
            count++;
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
        Console.WriteLine($"Standard Booking costs   |  € 2,95,-");
        Console.WriteLine("---------------------------------");

        Console.WriteLine($"\t       Total  € {GetPrice}, -");

        Console.WriteLine();

        //Voucher toepassen
        int usevoucher;
        int confirmvoucher;
        Voucher voucher1 = null;
        Account acc = GetAccount();
        if (acc.Vouchers.Count > 0)
        {
        bool X = false;
        while (X == false)
        {
            if (acc.Vouchers.Count == 1)
            {
                Console.WriteLine($"You have {acc.Vouchers.Count} voucher:");
            }
            else
            { 
                Console.WriteLine($"You have {acc.Vouchers.Count} vouchers:");
            }
            
            foreach (Voucher voucher in acc.Vouchers)
            {
                GenerateVoucher.PrintVoucher(voucher);
            }
            Console.WriteLine("Would you like to use a voucher?\n1. Yes\n2. No");
            string usevoucher0 = Console.ReadLine()!;
            while (int.TryParse(usevoucher0, out usevoucher) == false || (usevoucher0 != "1" && usevoucher0 != "2"))
            {
                Console.WriteLine("Please enter a valid input");
                Console.WriteLine("Do you have a voucher that you would like to use?\n1. Yes\n2. No");
                usevoucher0 = Console.ReadLine()!;
            }
            if (usevoucher == 2)
            {
                X = true;
            }
            else if (usevoucher == 1)
            {
                Console.WriteLine("Enter your vouchercode.");
                string code = Console.ReadLine()!;
                bool codeExists = false;
                foreach (Voucher voucher in GetAccount().Vouchers)
                {
                    if (code == voucher.VoucherCode)
                    {
                        voucher1 = voucher;
                        codeExists = true;
                        X = true;
                        break;
                    }
                }
                if (codeExists == false)
                {
                    Console.WriteLine("Incorrect vouchercode");
                }
                else
                {
                    GenerateVoucher.PrintVoucher(voucher1);
                    Console.WriteLine("Confirm to use the voucher above.\n1. Yes\n2. No");
                    string confirmvoucher0 = Console.ReadLine()!;
                    while (int.TryParse(confirmvoucher0, out confirmvoucher) == false || (confirmvoucher0 != "1" && confirmvoucher0 != "2"))
                    {
                        Console.WriteLine("Please enter a valid input");
                        Console.WriteLine("Confirm to use the voucher above.\n1. Yes\n2. No");
                        confirmvoucher0 = Console.ReadLine()!;
                    }
                    if (confirmvoucher == 1)
                    {
                        double discount = voucher1.Price;
                        Console.WriteLine("Total price including BTW/VAT");
                        Console.WriteLine(" --------------------------------");
                        Console.WriteLine($"Total Tickets            |  € {seatsprice},-");
                        Console.WriteLine($"Total Luggage            |  € {GetLugage.TotalCost},-");
                        Console.WriteLine($"Total Catering           |  € {CateringLogic.TotalPrice},-");
                        Console.WriteLine($"Standard Booking costs   |  € 2,95,-");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Voucher                  |  € {voucher1.Price}");
                        Console.ResetColor();
                        Console.WriteLine("---------------------------------");
                        if (GetPrice - voucher1.Price < 0)
                        {
                            GetPrice = 0;
                        }
                        else
                        {
                            GetPrice = GetPrice - voucher1.Price;
                        }
                        Console.WriteLine($"\t       Total  € {GetPrice}, -");
                        Console.WriteLine();

                        //Voucher verwijderen
                        acc.Vouchers.Remove(voucher1);
                        SetGetAccounts.UpdateAccountToJSON(acc);
                        X = true;
                    }
                }
            }
        }
        }
        ConfirmPrice();
    }

    public static void ConfirmPrice()
    { 
        Console.WriteLine("Confirm the price above.\n1.Yes\n2.No");
        Console.Write("> ");
        string answer = Console.ReadLine()!.ToUpper();

        bool x = true;
        while (x)
        {
            if (answer == "1")
            {
                if (MakePayment() == true) {
                    Account Account = null;
                    List<Account> accounts = SetGetAccounts.ReadAccountsFromJSON();

                    foreach (Account account in accounts)
                    {
                        if (account.LoggedIn == true)
                        {
                            Account = account;
                        }
                    }
                    foreach (BookTicket ticket in Tickets)
                    {
                        Account.BoughtTickets.Add(ticket);
                    }
                    //Hier update je het account met de boughttickets lijst
                    SetGetAccounts.UpdateAccountToJSON(Account);
                    Console.Clear();
                    TicketOverview.tickets = Tickets;
                    TicketOverview.Ticket(Tickets, payment);
                    x = false;
                }
                x = false;
                break;
            }
            else if (answer == "2")
            {
                // Verwijder persoonlijke gegevens uit json file en maak de ticket(s) weer beschikbaar!
                CancelBooking.BookingCancel(Tickets);
                x = false;
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }
        }
    }

    public static bool MakePayment()
    {
        Console.WriteLine();
        Console.WriteLine("Would you like to pay the whole price upfront?\n1: I would like to pay the whole price upfront.\n2: I would like to pay in two terms.");
        Console.Write("> ");
        string answer = Console.ReadLine()!.ToUpper();

        Console.WriteLine();
        Console.WriteLine("Redirected to payment screen...");
        Thread.Sleep(1000);
        Console.Clear();

        try
        {
            if (answer == "1")
            {
                try
                {
                    int paymentType;
                    Console.WriteLine($"Price to pay: {GetPrice}.");
                    Console.WriteLine();
                    Console.WriteLine("Payment options:\n(1) iDeal\n(2) PayPal\n(3) Master Card\n(4) Visa");
                    Console.Write("> ");
                    string paymentType0 = Console.ReadLine()!;
                    while (int.TryParse(paymentType0, out paymentType) == false || (paymentType0 != "1" && paymentType0 != "2" && paymentType0 != "3" && paymentType0 != "4"))
                    {
                        Console.WriteLine("Please enter a valid input.");
                        Console.WriteLine("Payment options:\n(1) iDeal\n(2) PayPal\n(3) Master Card\n(4) Visa");
                        Console.Write("> ");
                        paymentType0 = Console.ReadLine()!;
                    }

                    if (paymentType == 1)
                    {
                        bool x = true;
                        while (x)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Confirm payment by iDeal.\n1.Yes\n2.No");
                            Console.Write("> ");
                            string confirmPayment = Console.ReadLine()!.ToUpper();

                            if (confirmPayment == "1")
                            {
                                Console.WriteLine("Payment complete!");
                                Console.WriteLine("Your ticket(s) will be added to your account shortly.");
                                Console.WriteLine("Check your reservation in your account.");
                                payment = true;
                                x = false;
                                return true;

                            }
                            else if (confirmPayment == "2")
                            {
                                Console.WriteLine("Payment cancelled!");
                                Console.WriteLine("Try again...");
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
                            Console.WriteLine("Confirm payment by PayPal.\n1.Yes\n2.No");
                            Console.Write("> ");
                            string confirmPayment = Console.ReadLine()!.ToUpper();

                            if (confirmPayment == "1")
                            {
                                Console.WriteLine("Payment complete!");
                                Console.WriteLine("Your ticket(s) will be added to your account shortly.");
                                Console.WriteLine("Check your reservation in your account.");
                                payment = true;
                                x = false;
                                return true;

                            }
                            else if (confirmPayment == "2")
                            {
                                Console.WriteLine("Payment cancelled!");
                                Console.WriteLine("Try again...");
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
                            Console.WriteLine("Confirm payment by Master Card.\n1.Yes\n2.No");
                            Console.Write("> ");
                            string confirmPayment = Console.ReadLine()!.ToUpper();

                            if (confirmPayment == "1")
                            {
                                Console.WriteLine("Payment complete!");
                                Console.WriteLine("Your ticket(s) will be added to your account shortly.");
                                Console.WriteLine("Check your reservation in your account.");
                                payment = true;
                                x = false;
                                return true;

                            }
                            else if (confirmPayment == "2")
                            {
                                Console.WriteLine("Payment cancelled!");
                                Console.WriteLine("Try again...");
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
                            Console.WriteLine("Confirm payment by Visa.\n1.Yes\n2.No");
                            Console.Write("> ");
                            string confirmPayment = Console.ReadLine()!.ToUpper();

                            if (confirmPayment == "1")
                            {
                                Console.WriteLine("Payment complete!");
                                Console.WriteLine("Your ticket(s) will be added to your account shortly.");
                                Console.WriteLine("Check your reservation in your account.");
                                payment = true;
                                x = false;
                                return true;

                            }
                            else if (confirmPayment == "2")
                            {
                                Console.WriteLine("Payment cancelled!");
                                Console.WriteLine("Try again...");
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
            else if (answer == "2") // betaal in 2 termijnen
            {
                try
                {
                    int paymentType;
                    double pricePerTerm = GetPrice / 2.0;

                    Console.WriteLine($"Price to pay for term 1*: {pricePerTerm}");
                    Console.WriteLine($"*The next payment needs to be made no later than 12 hours before the flight.");

                    Console.WriteLine();
                    Console.WriteLine("Payment options:\n(1) iDeal\n(2) PayPal\n(3) Master Card\n(4) Visa");
                    Console.Write("> ");
                    string paymentType0 = Console.ReadLine()!;
                    while (int.TryParse(paymentType0, out paymentType) == false || (paymentType0 != "1" && paymentType0 != "2" && paymentType0 != "3" && paymentType0 != "3"))
                    {
                        Console.WriteLine("Please enter a valid input.");
                        Console.WriteLine("Payment options:\n(1) iDeal\n(2) PayPal\n(3) Master Card\n(4) Visa");
                        Console.Write("> ");
                        paymentType0 = Console.ReadLine()!;
                    }

                    if (paymentType == 1)
                    {
                        bool x = true;
                        while (x)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Confirm payment by iDeal.\n1.Yes\n2.No");
                            Console.Write("> ");
                            string confirmPayment = Console.ReadLine()!.ToUpper();

                            if (confirmPayment == "1")
                            {
                                Console.WriteLine("Payment 1/2 complete!");
                                Console.WriteLine("Your ticket(s) will be added to your account after the second payment");
                                Console.WriteLine("is completed. Pay remaining costs till 12 hours before your flight!");
                                payment = false;
                                x = false;
                                return true;

                            }
                            else if (confirmPayment == "2")
                            {
                                Console.WriteLine("Payment cancelled!");
                                Console.WriteLine("Try again...");
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
                            Console.WriteLine("Confirm payment by Paypal.\n1.Yes\n2.No");
                            Console.Write("> ");
                            string confirmPayment = Console.ReadLine()!.ToUpper();

                            if (confirmPayment == "1")
                            {
                                Console.WriteLine("Payment 1/2 complete!");
                                Console.WriteLine("Your ticket(s) will be added to your account after the second payment");
                                Console.WriteLine("is completed. Pay remaining costs till 12 hours before your flight!");
                                payment = false;
                                x = false;
                                return true;

                            }
                            else if (confirmPayment == "2")
                            {
                                Console.WriteLine("Payment cancelled!");
                                Console.WriteLine("Try again...");
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
                            Console.WriteLine("Confirm payment by Master Card.\n1.Yes\n2.No");
                            Console.Write("> ");
                            string confirmPayment = Console.ReadLine()!.ToUpper();

                            if (confirmPayment == "1")
                            {
                                Console.WriteLine("Payment 1/2 complete!");
                                Console.WriteLine("Your ticket(s) will be added to your account after the second payment");
                                Console.WriteLine("is completed. Pay remaining costs till 12 hours before your flight!");
                                payment = false;
                                x = false;
                                return true;

                            }
                            else if (confirmPayment == "2")
                            {
                                Console.WriteLine("Payment cancelled!");
                                Console.WriteLine("Try again...");
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
                            Console.WriteLine("Confirm payment by Visa.\n1.Yes\n2.No");
                            Console.Write("> ");
                            string confirmPayment = Console.ReadLine()!.ToUpper();

                            if (confirmPayment == "1")
                            {
                                Console.WriteLine("Payment 1/2 complete!");
                                Console.WriteLine("Your ticket(s) will be added to your account after the second payment");
                                Console.WriteLine("is completed. Pay remaining costs till 12 hours before your flight!");
                                payment = false;
                                x = false;
                                return true;

                            }
                            else if (confirmPayment == "2")
                            {
                                Console.WriteLine("Payment cancelled!");
                                Console.WriteLine("Try again...");
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
        Console.WriteLine("Would you like to pay term 2/2 to receive your ticket(s)?\n1.Yes\n2.No");
        Console.Write("> ");
        string answer = Console.ReadLine()!.ToUpper();

        Console.WriteLine();
        Console.WriteLine("Redirected to payment screen...");
        Thread.Sleep(1000);
        Console.Clear();

        try
        {
            if (answer == "1")
            {
                try
                {
                    int paymentType;
                    Console.WriteLine($"Price to pay: {remainingPrice}");
                    Console.WriteLine();
                    Console.WriteLine("Payment options:\n(1) iDeal\n(2) PayPal\n(3) Master Card\n(4) Visa");
                    Console.Write("> ");
                    string paymentType0 = Console.ReadLine()!;
                    while (int.TryParse(paymentType0, out paymentType) == false || (paymentType0 != "1" && paymentType0 != "2" && paymentType0 != "3" && paymentType0 != "3"))
                    {
                        Console.WriteLine("Please enter a valid input.");
                        Console.WriteLine("Payment options:\n(1) iDeal\n(2) PayPal\n(3) Master Card\n(4) Visa");
                        Console.Write("> ");
                        paymentType0 = Console.ReadLine()!;
                    }

                    if (paymentType == 1)
                    {
                        bool x = true;
                        while (x)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Confirm payment by iDeal.\n1.Yes\n2.No");
                            Console.Write("> ");
                            string confirmPayment = Console.ReadLine()!.ToUpper();

                            if (confirmPayment == "1")
                            {
                                Console.WriteLine("Payment complete!");
                                Console.WriteLine("Your ticket(s) will be added to your account shortly.");
                                Console.WriteLine("Check your reservation in your account.");
                                payment = true;
                                x = false;
                                return true;

                            }
                            else if (confirmPayment == "2")
                            {
                                Console.WriteLine("Payment cancelled!");
                                Console.WriteLine("Try again...");
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
                            Console.WriteLine("Confirm payment by PayPal.\n1.Yes\n2.No");
                            Console.Write("> ");
                            string confirmPayment = Console.ReadLine()!.ToUpper();

                            if (confirmPayment == "1")
                            {
                                Console.WriteLine("Payment complete!");
                                Console.WriteLine("Your ticket(s) will be added to your account shortly.");
                                Console.WriteLine("Check your reservation in your account.");
                                payment = true;
                                x = false;
                                return true;

                            }
                            else if (confirmPayment == "2")
                            {
                                Console.WriteLine("Payment cancelled!");
                                Console.WriteLine("Try again...");
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
                            Console.WriteLine("Confirm payment by Master Card.\n1.Yes\n2.No");
                            Console.Write("> ");
                            string confirmPayment = Console.ReadLine()!.ToUpper();

                            if (confirmPayment == "1")
                            {
                                Console.WriteLine("Payment complete!");
                                Console.WriteLine("Your ticket(s) will be added to your account shortly.");
                                Console.WriteLine("Check your reservation in your account.");
                                payment = true;
                                x = false;
                                return true;

                            }
                            else if (confirmPayment == "2")
                            {
                                Console.WriteLine("Payment cancelled!");
                                Console.WriteLine("Try again...");
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
                            Console.WriteLine("Confirm payment by Visa.\n1.Yes\n2.No");
                            Console.Write("> ");
                            string confirmPayment = Console.ReadLine()!.ToUpper();

                            if (confirmPayment == "1")
                            {
                                Console.WriteLine("Payment complete!");
                                Console.WriteLine("Your ticket(s) will be added to your account shortly.");
                                Console.WriteLine("Check your reservation in your account.");
                                payment = true;
                                x = false;
                                return true;

                            }
                            else if (confirmPayment == "2")
                            {
                                Console.WriteLine("Payment cancelled!");
                                Console.WriteLine("Try again...");
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
                Console.WriteLine("Note: You have until 12 hours before your flight to pay the remaining term!");
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

    public static Account GetAccount()
    {
        List<Account> accounts = SetGetAccounts.ReadAccountsFromJSON();

        foreach (Account account in accounts)
        {
            if (account.LoggedIn == true)
            {
                return account;
            }
        }
        return null;
    }
}
