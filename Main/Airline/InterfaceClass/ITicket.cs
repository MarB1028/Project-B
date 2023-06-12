public interface ITicket
{
    Passenger Passenger { get; set; }
    Flight Flight { get; set; }
    Seat Seat { get; set; }
    string Gate { get; set; }
}