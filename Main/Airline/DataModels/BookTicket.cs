class BookTicket
{
    private static int ticketCounter = 0;
    public bool Booked;
    public int TicketID;
    public Passenger Passenger;
    public Ticket Ticket;
    
    public BookTicket(Passenger passenger, Ticket ticket)
    {
        Booked = false;
        TicketID = ++ticketCounter;
        Passenger = passenger;
        Ticket = ticket;
    }

    public static void ResetCounter()
    {
        ticketCounter = 0;
    }
}