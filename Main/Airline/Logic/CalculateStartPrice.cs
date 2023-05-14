static class CalculateStartPrice
{
    public static void ApplyDeal()
    {
        List<Flight> flights = DataFlights.ReadFlightsFromJson();
        DateTime now = DateTime.Now;

        foreach (Flight flight in flights)
        {
            double hoursleft = (flight.BoardingDate - now).TotalHours;

            if (hoursleft <= 3)
            {
                flight.MinPrice = flight.MinPrice * 0.25; // 75% korting
                flight.IsDeal = true;
            }
            else if (hoursleft <= 4)
            {
                flight.MinPrice = flight.MinPrice * 0.50; // 50% korting
                flight.IsDeal = true;
            }
            else if (hoursleft <= 5)
            {
                flight.MinPrice = flight.MinPrice * 0.75; // 25% korting   
                flight.IsDeal = true; 
            }
            else
            {
                flight.IsDeal = false;
            }
        }
        DataFlights.WriteDateToJson(flights);
    }

    
}