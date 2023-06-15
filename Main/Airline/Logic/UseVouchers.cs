static class UseVouchers
{
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

    public static void Use()
    {
        int usevoucher;
        int confirmvoucher;
        Voucher voucher1 = null;
        Account acc = GetAccount();
        if (acc.Vouchers.Count <= 0)
        {
            return;
        }

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
                foreach (Voucher voucher in acc.Vouchers)
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
                    double GetPrice = CalculateTotalCosts.GetTotalPrice() + +2.95;
                    Console.WriteLine("Total price including BTW/VAT");
                    Console.WriteLine(" --------------------------------");
                    Console.WriteLine($"Total Tickets            |  € {CalculateTotalCosts.seatsprice},-");
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
}