using Newtonsoft.Json;
class BookTicket
{   
    // Account doorgeven nog om aan de ticket te koppelen.
    public bool Booked;
    public Ticket Ticket;
    // public Account account;

    public BookTicket(Ticket ticket)
    {
        Booked = false;
        Ticket = ticket;
    }

   
    // Een beschikbare stoel boeken.
    public void BookSeat()
    {
        // Hier moet ik nog aan werken.
    }
}