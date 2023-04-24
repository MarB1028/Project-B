static class Deals
{

    public static void UpdatePrice( Flight flight)
    {
        DateTime now = DateTime.Now;
        double hoursleft = (flight.BoardingDate - now).TotalHours;

        if (hoursleft <= 3)
        {
            flight.MinPrice *= 0.75; // 25% korting
            flight.IsDeal = true;
        }
        else if (hoursleft <= 4)
        {
            flight.MinPrice *= 0.5; // 50% korting
            flight.IsDeal = true;
        }
        else if (hoursleft <= 5)
        {
            flight.MinPrice *= 0.25; // 75% korting   
            flight.IsDeal = true; 
        }
    }
}