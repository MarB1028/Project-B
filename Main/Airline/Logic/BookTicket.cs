class BookTicket
{   
    // Account doorgeven nog om aan de ticket te koppelen.
    public bool Booked;
    public int TicketID;
    public Ticket Ticket;
    // public Account account;

    public BookTicket(int ticketid, Ticket ticket)
    {
        Booked = false;
        TicketID = ticketid;
        Ticket = ticket;
    }

    // Een beschikbare stoel boeken.
    public void BookSeat()
    {
        // Hier moet ik nog aan werken.
    }
}