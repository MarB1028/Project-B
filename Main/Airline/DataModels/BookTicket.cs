public class BookTicket
{
    private static int ticketCounter = 0;
    public bool Booked;
    public string BookingsCode;
    public bool PaymentDone;
    public int TicketID;
    public Ticket Ticket;
    
    public BookTicket(Ticket ticket)
    {
        Booked = false;
        BookingsCode = null!;
        PaymentDone = false;
        TicketID = ++ticketCounter;
        Ticket = ticket;
    }

    public static void ResetCounter()
    {
        ticketCounter = 0;
    }
}