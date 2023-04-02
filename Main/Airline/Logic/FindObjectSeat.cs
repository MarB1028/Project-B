class FindObjectSeat
{
    public Seat FindSeatObject(Flight flight, string seatnumber)
    {
        List<BookTicket> data = new DataTickets().ReadTicketsFromJson(flight);

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