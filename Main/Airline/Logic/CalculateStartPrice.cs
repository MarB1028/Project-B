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

            if (flight.BoardingDate <= DateTime.Now)
            {
                flight.IsDeal = false;
            }
            else if (hoursleft == 3)
            {
                flight.MinPrice = Math.Ceiling((flight.MinPrice * Math.Pow(1.1, 14) * 0.25)); // 75% korting
                flight.IsDeal = true;
            }
            else if (hoursleft == 4)
            {
                flight.MinPrice = Math.Ceiling((flight.MinPrice * Math.Pow(1.1, 14) * 0.50)); // 50% korting
                flight.IsDeal = true;
            }
            else if (hoursleft == 5)
            {
                flight.MinPrice = Math.Ceiling((flight.MinPrice * Math.Pow(1.1, 14) * 0.75)); // 25% korting   
                flight.IsDeal = true; 
            }
            else
            {
                flight.IsDeal = false;
                TimeSpan timeToDeparture = flight.BoardingDate - DateTime.Now;
                double daysToDeparture = timeToDeparture.TotalDays;
                double hoursToDeparture = timeToDeparture.TotalHours;

                if (daysToDeparture <= 14 && hoursToDeparture >= 24)
                {
                    double riseFactor = 1.1;
                    flight.MinPrice = Math.Ceiling((flight.BasePrice * Math.Pow(riseFactor, daysToDeparture)));
                }
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