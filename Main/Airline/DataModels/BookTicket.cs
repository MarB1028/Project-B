public class BookTicket : IBookTicket
{
    public BookTicket(Ticket ticket) : base(ticket)
    {

    }

    public override void ResetCounter()
    {
        ticketCounter = 0;
    }
}