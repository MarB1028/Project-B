class Program
{
    public static void Main()
    {
        // OM JE EIGEN CODE TE TESTEN, (SHIFT + CONTROL + /) OM DE COMMENTS WEG TE HALEN
        Luggage.LuggageInfo();

        // CODE TEST [Jiajun]
        /*Airplane boeing747 = new Airplane("BOEING747", "BO", 1, 4, 5, 6, 2);

        Destination frankfort = new Destination("GER", "FRA", "FRANKFORTAIRPORT", 100, 2);
        Destination mannenheim = new Destination("GER", "MAN", "MANNENHEIMAIRPORT", 100, 2);
        Flight flightfrankfort = new Flight("GER1", boeing747, DateTime.Now, DateTime.Now, frankfort);
        Flight flightmannenheim = new Flight("GER2", boeing747, DateTime.Now, DateTime.Now, mannenheim);

        MakeOverviewFlightJson.MakeOverviewJson(flightfrankfort);
        MakeOverviewFlightJson.MakeOverviewJson(flightmannenheim);

        MakeTicketsForFlightJson.MakeTickets(flightfrankfort);
        MakeTicketsForFlightJson.MakeTickets(flightmannenheim);
        
        BookTicket test = new BookTicket(new Ticket("Jiajun", "Li", flightmannenheim, FindObjectSeat.FindSeatObject(flightmannenheim, "BO-1"), "G18"));
        DataTickets.WriteTicketToJson(flightmannenheim, test);*/

        // CODE TEST [Soufiane]
        /*PassengerForm.Form();*/

        // CODE TEST [Marissa]
        /*Login.LoginpageMessage();*/

        // CODE TEST [Marie-Claire]
        /*Airplane boeing747 = new Airplane("BOEING747", "BO", 1, 4, 5, 6, 2);
        Destination frankfort = new Destination("GER", "FRA", "FRANKFORTAIRPORT", 100, 2);
        Flight flightfrankfort = new Flight("GER1", boeing747, DateTime.Now, DateTime.Now, frankfort);
        CheckSeatAvailability checkSeatAvailability = new CheckSeatAvailability(flightfrankfort);
        checkSeatAvailability.AvailableSeats();*/

        // CODE TEST [Maria]
        /*Menu.StartScreen();*/
        //PassengerForm.Form();
    }
}