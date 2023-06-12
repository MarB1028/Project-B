public class Seat : ISeat
{
    public string SeatNumber { get; set; }
    public string SeatType { get; set; }
    public double Price { get; set; }

    public Seat(string seatNumber, string seattype, double price)
    {
        
        SeatNumber = seatNumber;
        SeatType = seattype;
        Price = price;
    }
}