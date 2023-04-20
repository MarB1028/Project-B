static class CalculateTotalCosts
{
    public static List<BookTicket> tickets;
    public static double TotalCost;

    public static double GetTotalPrice() {
        foreach (BookTicket ticket in tickets) {
            TotalCost = TotalCost + GetSeatPrice(ticket);
        }
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
