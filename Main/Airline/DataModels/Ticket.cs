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
}