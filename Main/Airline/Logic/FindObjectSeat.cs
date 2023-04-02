static class FindObjectSeat
{
    public static Seat FindSeatObject(Flight flight, string seatnumber)
    {
        List<BookTicket> data = DataTickets.ReadTicketsFromJson(flight);

        foreach (BookTicket i in data)
        {
            if (i.Ticket.Seat.SeatNumber == seatnumber)
            {
                return i.Ticket.Seat;
            }
        }
        return null;
    }
}