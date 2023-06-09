static class ViewVouchers
{
    public static Account account1;
    public static void Info()
    {
        //

        if (Exists() == false)
        {
            Console.WriteLine("You have no vouchers.");
            Console.WriteLine("Press any key to return to the menu");
            string key = Console.ReadLine();
            Console.WriteLine("Redirecting you back to the menu...");
            Thread.Sleep(3000);
            Menu.StartScreen();
        }
        else
        {
            PrintVouchers();
        }
    }

    public static bool Exists()
    {
        List<Account> accounts = SetGetAccounts.ReadAccountsFromJSON();

        foreach (Account account in accounts)
        {
            if (account.LoggedIn == true)
            {
                account1 = account;
                if (account.Vouchers.Count > 0)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public static void PrintVouchers()
    {
        Console.WriteLine();
        Console.WriteLine($"You have {account1.Vouchers.Count} voucher(s):");

        foreach (Voucher voucher in account1.Vouchers)
        {
            Console.WriteLine();
            GenerateVoucher.PrintVoucher(voucher);
            Console.WriteLine();
        }
        Console.WriteLine("Press any key to return to the menu");
        string key = Console.ReadLine();
        Console.WriteLine("Redirecting you back to the menu...");
        Thread.Sleep(3000);
        Menu.StartScreen();
        
    }
}