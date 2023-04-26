public class Ticket
{
    public Passenger Passenger;
    public Flight Flight;
    public Seat Seat;
    public string Gate;

    public Ticket(Passenger passenger, Flight flight, Seat seat, string gate)
    {
        Passenger = passenger;
        Flight = flight;
        Seat = seat;
        Gate = gate;
    }
}