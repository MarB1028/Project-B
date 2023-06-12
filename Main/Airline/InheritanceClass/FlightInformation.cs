public class FlightInformation
{
    public string DayOrNight { get; set; }
    public Airplane Airplane { get; set; }
    public DateTime BoardingDate { get; set; }
    public DateTime EstimatedArrival { get; set; }
    public Destination Destination { get; set; }
    public double BasePrice { get; set; }
    public double MinPrice { get; set; }
    public int TotalSeats { get; set; }

    public FlightInformation(string dayOrNight, Airplane airplane, DateTime boardingdate, DateTime estimatedarrival, Destination destination, double basePrice, int totalSeats)
    {
        DayOrNight = dayOrNight;
        Airplane = airplane;
        BoardingDate = boardingdate;
        EstimatedArrival = estimatedarrival;
        Destination = destination;
        BasePrice = basePrice;
        MinPrice = BasePrice;
        TotalSeats = totalSeats;
    }

    public override string ToString()
    {
        return $"Flight Time: {DayOrNight}, Airplane: {Airplane.Name}, Boardingdate: {BoardingDate.ToString()}, Estimatedarrival: {EstimatedArrival.ToString()}, Destination: {Destination}, Base price: {BasePrice}, Minimal price: {MinPrice}, Totalseats: {TotalSeats}";
    }
}