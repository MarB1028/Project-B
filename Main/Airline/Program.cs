class Program
{
    public static void Main()
    {
        Airplane boeing747 = new Airplane("BOEING747", "BO", 1, 4, 5, 6, 2);

        Destination frankfort = new Destination("GER", "FRA", "FRANKFORTAIRPORT", 100, 2);
        Destination mannenheim = new Destination("GER", "MAN", "MANNENHEIMAIRPORT", 100, 2);
        Flight flightfrankfort = new Flight("GER1", boeing747, DateTime.Now, DateTime.Now, frankfort);
        Flight flightmannenheim = new Flight("GER2", boeing747, DateTime.Now, DateTime.Now, mannenheim);

        MakeOverviewFlightJson.MakeOverviewJson(flightfrankfort);
        MakeOverviewFlightJson.MakeOverviewJson(flightmannenheim);

        MakeTicketsForFlightJson.MakeTickets(flightfrankfort);
        MakeTicketsForFlightJson.MakeTickets(flightmannenheim);

        Passenger passenger = new Passenger("Jiajun", "Li", "M", DateTime.Now, "Hamburg", "123456789");
        BookTicket test = new BookTicket(passenger, new Ticket("Jiajun", "Li", flightmannenheim, FindObjectSeat.FindSeatObject(flightmannenheim, "BO-1"), "G18"));
        DataTickets.WriteTicketToJson(flightmannenheim, test);
    }
}