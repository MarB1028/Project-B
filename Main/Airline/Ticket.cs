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

    public void PrintTicket()
    {
        Console.WriteLine($"Flight: {Flight.FlightId}");
        Console.WriteLine($"Destination: {Flight.Destination}");
        Console.WriteLine($"Boarding time: {Flight.BoardingDate}");
        Console.WriteLine($"Arrrival time: {Flight.EstimatedArrival}");
        Console.WriteLine($"Seat number: {Seat.SeatNumber}");
        Console.WriteLine($"Seat type: {Seat.SeatType}");
        Console.WriteLine($"Gate: {Gate}");
        Console.WriteLine($"Ticket price: {Seat.Price}$");
    }
}