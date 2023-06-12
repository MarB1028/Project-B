public abstract class IBookTicket
{
    protected static int ticketCounter = 0;
    public bool Booked { get; set; }
    public bool PaymentDone { get; set; }
    public int TicketID { get; set; }
    public Ticket Ticket { get; set; }

    public IBookTicket(Ticket ticket)
    {
        Booked = false;
        PaymentDone = false;
        TicketID = ++ticketCounter;
        Ticket = ticket;
    }

    public abstract void ResetCounter();
}