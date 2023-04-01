class BookTicket
{
    private static int ticketCounter = 0;
    public bool Booked;
    public int TicketID;
    public Ticket Ticket;
    // public Passenger passenger;
    
    public BookTicket(Ticket ticket)
    {
        Booked = false;
        TicketID = ++ticketCounter;
        Ticket = ticket;
    }

    public void ResetCounter()
    {
        ticketCounter = 0;
    }
}