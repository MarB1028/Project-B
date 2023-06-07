static class GenerateVoucher
{
    public static string VoucherCode;
    
    //Er wordt een Voucher object aangemaakt
    public static void CreateVoucherObj(BookTicket bookTicket, double price)
    {
        //Gegevens voor de voucher worden uit bookticket gehaald
        string voucherCode = GenerateVoucherCode();
        DateTime cancellationdate = DateTime.Now;
        DateTime expirationdate = cancellationdate.AddYears(1);
        string destination = bookTicket.Ticket.Flight.Destination.City;
        string abbreviation = bookTicket.Ticket.Flight.Destination.Abbreviation;
        string departure = bookTicket.Ticket.Flight.BoardingDate.ToString("yyyy-MM-dd HH:mm");
        string flightinfo = $"{destination} ({abbreviation})  {departure}";

        Voucher voucher = new Voucher(voucherCode, cancellationdate, expirationdate, flightinfo, price);
        AddVoucher(voucher);
        VoucherMessage(voucher);
        PrintVoucher(voucher);

    }

    public static string GenerateVoucherCode()
    {
        return "ABC123XYZ";
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
        Console.WriteLine("The voucher has succesfully been added to your account.");
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
        Console.Write($"{voucher.Cancellationdate}");
        Console.Write(VoucherLine(10, voucher.Cancellationdate.ToString().Length));

        Console.Write("\t\t\t\t║  Flight: ");
        Console.Write($"{voucher.Flightinfo}");
        Console.Write(VoucherLine(6, voucher.Flightinfo.Length));

        Console.Write("\t\t\t\t║  Expiration date: ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write($"{voucher.Expirationdate}");
        Console.ResetColor();
        Console.Write(VoucherLine(15, voucher.Expirationdate.ToString().Length));
        Console.WriteLine("\t\t\t\t║                                               ║");
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