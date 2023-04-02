class Program
{
    public static void Main()
    {
        // OM JE EIGEN CODE TE TESTEN, (SHIFT + CONTROL + /) OM DE COMMENTS WEG TE HALEN


        // CODE TEST [Jiajun]
        /*Airplane boeing747 = new Airplane("BOEING747", "BO", 1, 4, 5, 6, 2);

        Destination frankfort = new Destination("GER", "FRA", "FRANKFORTAIRPORT", 100, 2);
        Destination mannenheim = new Destination("GER", "MAN", "MANNENHEIMAIRPORT", 100, 2);
        Flight flightfrankfort = new Flight("GER1", boeing747, DateTime.Now, DateTime.Now, frankfort);
        Flight flightmannenheim = new Flight("GER2", boeing747, DateTime.Now, DateTime.Now, mannenheim);

        MakeOverviewFlightJson overview = new MakeOverviewFlightJson();
        overview.MakeOverviewJson(flightfrankfort);
        MakeOverviewFlightJson overview1 = new MakeOverviewFlightJson();
        overview1.MakeOverviewJson(flightmannenheim);

        MakeTicketsForFlightJson flightgermany = new MakeTicketsForFlightJson();
        flightgermany.MakeTickets(flightfrankfort);
        MakeTicketsForFlightJson flightgermany1 = new MakeTicketsForFlightJson();
        flightgermany1.MakeTickets(flightmannenheim);

        BookTicket test = new BookTicket(new Ticket("Jiajun", "Li", flightmannenheim, new FindObjectSeat().FindSeatObject(flightmannenheim, "BO-1"), "G18"));
        new DataTickets().WriteTicketToJson(flightmannenheim, test);*/

        // CODE TEST [Soufiane]
        /*PassengerForm form = new PassengerForm();
        form.Form();*/

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
    }
}