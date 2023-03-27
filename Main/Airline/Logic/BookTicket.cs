class BookTicket
{
    // Account doorgeven nog om aan de ticket te koppelen.
    private static int _ticketid;

    public bool Booked;
    public int TicketID;
    public Ticket Ticket;
    // public Account account;

    public BookTicket(Ticket ticket)
    {
        _ticketid++;
        Booked = false;
        TicketID = _ticketid;
        Ticket = ticket;
    }

    // Een beschikbare stoel boeken.
    public void BookSeat()
    {
        // Hier moet ik nog aan werken.
    }
}