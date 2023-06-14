using System.Globalization;

public static class CalculateTotalCosts
{
    public static string BookingCode;
    public static List<BookTicket> tickets;
    public static double TotalCost;
    public static double seatsprice = 0;

    public static double GetTotalPrice()
    {
        foreach (BookTicket ticket in tickets)
        {
            seatsprice += GetSeatPrice(ticket);
        }
        TotalCost += seatsprice;
        TotalCost += GetLugage.TotalCost;
        TotalCost += CateringLogic.TotalPrice;
        return TotalCost;
    }

    public static double GetSeatPrice(BookTicket ticket)
    {
        Passenger passenger = ticket.Ticket.Passenger;
        int age = DateTime.Today.Year - passenger.BirthDate.Year;
        switch (age)
        {
            case >= 0 and <= 3:
                return 0 * ticket.Ticket.Seat.Price;
            case >= 4 and <= 12:
                return 0.35 * ticket.Ticket.Seat.Price;
            case >= 13 and <= 17:
                return 0.65 * ticket.Ticket.Seat.Price;
            case >= 18:
                return 1 * ticket.Ticket.Seat.Price;
            default:
                return 0;
        }
    }

    public static void Bookingscode()
    {
        Random random = new Random();

        // Generate three random letters
        char letter1 = (char)random.Next('A', 'Z' + 1);
        char letter2 = (char)random.Next('A', 'Z' + 1);
        char letter3 = (char)random.Next('A', 'Z' + 1);

        // Generate three random numbers
        int number1 = random.Next(0, 10);
        int number2 = random.Next(0, 10);
        int number3 = random.Next(0, 10);

        // Combine the letters and numbers to form the booking number
        var bookingNumber = $"{letter1}{letter2}{letter3}{number1}{number2}{number3}";
        BookingCode = bookingNumber;
    }
}