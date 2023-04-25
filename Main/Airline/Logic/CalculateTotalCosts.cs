static class CalculateTotalCosts
{
    //TODO: Hier moet elke keer een unieke bookingcode worden gegenereerd met 3 letters/3 cijfers
    public static string BookingCode = "ABC123";
    public static List<BookTicket> tickets;
    public static double TotalCost;

    public static double GetTotalPrice() {
        double seatsprice = 0;
        foreach (BookTicket ticket in tickets) {
            seatsprice += GetSeatPrice(ticket);
        }
        TotalCost += seatsprice;
        TotalCost += GetLugage.TotalCost;
        TotalCost += CatteringLogic.TotalPrice;
        Console.WriteLine($"Seats price: {seatsprice}\nLugage price:{GetLugage.TotalCost} \nCatering price:{CatteringLogic.TotalPrice}");
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
    
    
}