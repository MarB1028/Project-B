class BookTicket
{   
    // Account doorgeven nog om aan de ticket te koppelen.
    public bool Booked;
    public Ticket Ticket;
    // Account account;

    public BookTicket(Ticket ticket)
    {
        Booked = false;
        Ticket = ticket;
    }

    // Checkt als de stoel vrij is.
    public void CheckSeatAvailability()
    {
        // Hier moet ik nog aan werken.
    }

    // Print de beschikbare stoelen.
    public void AvailableSeats()
    {
        // Hier moet ik nog aan werken.
    }

    // Een beschikbare stoel boeken.
    public void BookSeat()
    {
        // Hier moet ik nog aan werken.
    }
}