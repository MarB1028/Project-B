public class Ticket : ITicket
{
    public Passenger Passenger { get; set; }
    public Flight Flight { get; set; }
    public Seat Seat { get; set; }
    public string Gate { get; set; }

    public Ticket(Passenger passenger, Flight flight, Seat seat, string gate)
    {
        Passenger = passenger;
        Flight = flight;
        Seat = seat;
        Gate = gate;
    }
}