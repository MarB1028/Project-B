static class GenerateVoucher
{
    public static string VoucherCode;
    
    //Er wordt een Voucher object aangemaakt
    public static void CreateVoucherObj(Ticket ticket, double price)
    {
        //Gegevens voor de voucher worden uit bookticket gehaald
        string voucherCode = GenerateVoucherCode();
        DateTime cancellationdate = DateTime.Now;
        DateTime expirationdate = cancellationdate.AddYears(1);
        string destination = ticket.Flight.Destination.City;
        string abbreviation = ticket.Flight.Destination.Abbreviation;
        string departure = ticket.Flight.BoardingDate.ToString("yyyy-MM-dd HH:mm");
        string flightinfo = $"{destination} ({abbreviation})  {departure}";

        Voucher voucher = new Voucher(voucherCode, cancellationdate, expirationdate, flightinfo, price);
        AddVoucher(voucher);
        VoucherMessage(voucher);
    }

    public static string GenerateVoucherCode()
    {
        string voucherCode = "";
        bool codeExists = true;

        //Het formaat van een vouchercode is ABC123XYZ. Hierdoor kunnen er 308.915.776.000 vouchercodes worden gegenereerd
        string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string numbers = "0123456789";
        Random random = new Random();

        while (codeExists == true)
        {
            codeExists = false;
            voucherCode = "";

            //Drie letters worden gegenereerd
            for (int i = 0; i <= 2; i ++)
            {
                int index = random.Next(0, letters.Length - 1);
                voucherCode = $"{voucherCode}{letters[index]}";
            }

            //Drie cijfers worden gegenereerd
            for (int i = 0; i <= 2; i ++)
            {
                int index = random.Next(0, numbers.Length - 1);
                voucherCode = $"{voucherCode}{numbers[index]}";
            }

            //Drie letters worden gegenereerd
            for (int i = 0; i <= 2; i ++)
            {
                int index = random.Next(0, letters.Length - 1);
                voucherCode = $"{voucherCode}{letters[index]}";
            }

            // Dit controleert of de code als bestaat. Zo ja, dan wordt er een nieuwe code gegenereerd
            List<Account> accounts = SetGetAccounts.ReadAccountsFromJSON();
            foreach (Account account in accounts)
            {
                foreach (Voucher voucher in account.Vouchers)
                {
                    if (voucherCode == voucher.VoucherCode)
                    {
                        codeExists = true;
                    }
                }
            }
            if (codeExists == false)
            {
                return voucherCode;
            }
        }
        return voucherCode;
    }

    
    //De voucher wordt toegevoegd aan het account
    public static void AddVoucher(Voucher voucher)
    {
        List<Account> accounts = SetGetAccounts.ReadAccountsFromJSON();

        foreach (Account account in accounts)
        {
            if (account.LoggedIn == true)
            {
                account.Vouchers.Add(voucher);
            }
        }

        SetGetAccounts.WriteAccountToJSON(accounts);
    }

    public static void VoucherMessage(Voucher voucher)
    {
        //Melding voor de gebruiker
        Console.WriteLine("Adding the voucher to your account...");
        Thread.Sleep(3000);
        Console.WriteLine("The voucher has succesfully been added to your account and expires in a year.");
        PrintVoucher(voucher);

    }

    public static void PrintVoucher(Voucher voucher)
    {
        Console.WriteLine();
        Console.WriteLine("\t\t\t\t╔═══════════════════════════════════════════════╗");
        Console.WriteLine("\t\t\t\t║                    Voucher                    ║");
        Console.WriteLine("\t\t\t\t║                                               ║");

        Console.Write("\t\t\t\t║  Code: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($"{voucher.VoucherCode}");
        Console.ResetColor();
        Console.Write(VoucherLine(4, voucher.VoucherCode.Length));

        Console.Write("\t\t\t\t║  Amount: ");
        Console.Write($"{voucher.Price}");
        Console.Write(VoucherLine(6, voucher.Price.ToString().Length));

        Console.Write("\t\t\t\t║  Start date: ");
        Console.Write($"{voucher.Cancellationdate.ToString("yyyy-MM-dd")}");
        Console.Write(VoucherLine(10, voucher.Cancellationdate.ToString("yyyy-MM-dd").Length));

        Console.Write("\t\t\t\t║  Flight: ");
        Console.Write($"{voucher.Flightinfo}");
        Console.Write(VoucherLine(6, voucher.Flightinfo.Length));

        Console.Write("\t\t\t\t║  Expiration date: ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write($"{voucher.Expirationdate.ToString("yyyy-MM-dd")}");
        Console.ResetColor();
        Console.Write(VoucherLine(15, voucher.Expirationdate.ToString("yyyy-MM-dd").Length));
        Console.WriteLine("\t\t\t\t║                                               ║");
        Console.WriteLine("\t\t\t\t║                                               ║");
        Console.WriteLine("\t\t\t\t║                                               ║");
        Console.WriteLine("\t\t\t\t╚═══════════════════════════════════════════════╝");

    }

    public static string VoucherLine(int a, int b)
    {
        string spaces = new string(' ', 43 - a - b);
        return $"{spaces}║\n";
    }

    
}