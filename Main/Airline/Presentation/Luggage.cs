static class Luggage
{
    public static void LuggageInfo(List<BookTicket> tickets)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("STEP 3/5: Add hand luggage and/or check-in luggage");
        Console.WriteLine("===============================================");
        Console.ResetColor();
        /* Voor het gehele process de stappen vermelden? 
         * In het begin het aantal stappen vermelden?
         * -> Book your ticket in 3 easy steps! */
        Console.WriteLine("Information:\n+ Every passenger is allowed to bring {0}one piece{1} of hand luggage free of charge.\n  The maximum weight is {0}10 KG{1} and the maximum of hand luggage allowed is {0}two{1} p.p.", "\u001b[1m", "\u001b[0m");
        Console.WriteLine("+ The maximum weight of check-in luggage starts from {0}23 KG{1}\n  and the maximum amount of check-in luggage allowed is {0}two{1} p.p.", "\u001b[1m", "\u001b[0m");
        Console.WriteLine();
        Console.OutputEncoding = System.Text.Encoding.UTF8; // weergave euro tekens
        Console.WriteLine($"Extra hand luggage: \u20AC 25,- (Excl. BTW/VAT)\nCheck-in luggage: \u20AC 55,- per luggage (Excl. BTW/VAT)");

        GetLugage.tickets = tickets;
        GetLugage.CostsAllLuggage();
    }
}