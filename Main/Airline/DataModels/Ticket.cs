class Ticket
{
    public string FirstName;
    public string LastName;
    public Flight Flight;
    public Seat Seat;
    public string Gate;

    public Ticket(string firstname, string lastname, Flight flight, Seat seat, string gate)
    {
        FirstName = firstname;
        LastName = lastname;
        Flight = flight;
        Seat = seat;
        Gate = gate;
    }

    // Print de ticket van de klant, met het doorgegeven voornaam en achternaam (Concept).
    // Kan ook iets anders doorgegeven en de ticket uitprinten.
    public void PrintTicket(string firstname, string lastname)
    {
        // Hier moet ik nog aan werken
    }
}