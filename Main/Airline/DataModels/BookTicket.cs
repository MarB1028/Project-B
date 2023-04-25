public class BookTicket
{
    private static int ticketCounter = 0;
    public bool Booked;
    public int TicketID;
    public Ticket Ticket;
    
    public BookTicket(Ticket ticket)
    {
        Booked = false;
        TicketID = ++ticketCounter;
        Ticket = ticket;
    }

    public static void ResetCounter()
    {
        ticketCounter = 0;
    }
}