static class CalculateStartPrice
{
    public static void ApplyDeals()
    {
        List<Flight> flights = DataFlights.ReadFlightsFromJson();
        DateTime now = DateTime.Now;

        foreach (Flight flight in flights)
        {
            flight.MinPrice = flight.BasePrice;
            double hoursleft = (flight.BoardingDate - now).TotalHours;

            if (hoursleft <= 3)
            {
                flight.MinPrice = Math.Round((flight.MinPrice * Math.Pow(1.1, 14) * 0.25), 2); // 75% korting
                flight.IsDeal = true;
            }
            else if (hoursleft <= 4)
            {
                flight.MinPrice = Math.Round((flight.MinPrice * Math.Pow(1.1, 14) * 0.50), 2); // 50% korting
                flight.IsDeal = true;
            }
            else if (hoursleft <= 5)
            {
                flight.MinPrice = Math.Round((flight.MinPrice * Math.Pow(1.1, 14) * 0.75), 2); // 25% korting   
                flight.IsDeal = true; 
            }
            else
            {
                flight.IsDeal = false;
            }
        }
        DataFlights.WriteDateToJson(flights);
    }

    public static void ApplyPriceRise()
    {
        List<Flight> flights = DataFlights.ReadFlightsFromJson();
        

        foreach (Flight flight in flights)
        {
            TimeSpan timeToDeparture = flight.BoardingDate - DateTime.Now;
            double daysToDeparture = timeToDeparture.TotalDays;
            double hoursToDeparture = timeToDeparture.TotalHours;
            
            if (daysToDeparture <= 14 && hoursToDeparture >= 24)
            {
                double riseFactor = 1.1;
                flight.MinPrice = Math.Round((flight.BasePrice * Math.Pow(riseFactor, daysToDeparture)), 2);
            }
        }
        DataFlights.WriteDateToJson(flights);
    }

    public static double CalculateSeat(string seattype) {
        double BasePrice = 100;
        double totalprice = BasePrice;

        if (seattype == "First-Class") {
            totalprice = BasePrice * 6;
        }
        else if (seattype == "Premium-Class") {
            totalprice = BasePrice * 3;
        }
        else if (seattype == "ExtraSpace-Class") {
            totalprice = BasePrice + 75;
        }
        else if (seattype == "Economy-Class") {
            totalprice = BasePrice;
        }

        return totalprice;
    }
    
}