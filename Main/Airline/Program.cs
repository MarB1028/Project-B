class Program
{
    public static void Main()
    {
        // Functionaliteit 1:
        /*Airplane boeing747 = new Airplane("BOEING747", "BO", 1, 4, 5, 6, 2);
        Destination frankfort = new Destination("GER", "FRA", "FRANKFORTAIRPORT", 100, 2);
        Destination mannenheim = new Destination("GER", "MAN", "MANNENHEIMAIRPORT", 100, 2);
        Flight flightfrankfort = new Flight("GER1", boeing747, DateTime.Now, DateTime.Now, frankfort);
        Flight flightmannenheim = new Flight("GER2", boeing747, DateTime.Now, DateTime.Now, mannenheim);

        MakeOverviewFlightJson.MakeOverviewJson(flightfrankfort);
        MakeOverviewFlightJson.MakeOverviewJson(flightmannenheim);

        MakeTicketsForFlightJson.MakeTickets(flightfrankfort);
        MakeTicketsForFlightJson.MakeTickets(flightmannenheim);*/

        // Functionaliteit 2:
        /*BookTicket test = new BookTicket(new Ticket(null, flightmannenheim, FindObjectSeat.FindSeatObject(flightmannenheim, "BO-1"), "G18"));
        DataTickets.WriteTicketToJson(flightmannenheim, test);*/

        // Functionaliteit 3:
        /*AddFoodForm.FoodForm();*/

        // STAP 1, 2
        /*Menu.StartScreen();*/

        // STAP 3, 4
        /*Airplane boeing747 = new Airplane("BOEING747", "BO", 1, 4, 5, 6, 2);
        Destination frankfort = new Destination("GER", "FRA", "FRANKFORTAIRPORT", 100, 91);
        Flight flightfrankfort = new Flight("GER1", boeing747, DateTime.Now, DateTime.Now, frankfort);
        CheckSeatAvailability checkSeatAvailability = new CheckSeatAvailability(flightfrankfort);
        checkSeatAvailability.AvailableSeats();*/

        // STAP 5
        /*Airplane boeing747 = new Airplane("BOEING747", "BO", 1, 4, 5, 6, 2);
        Destination frankfort = new Destination("GER", "FRA", "FRANKFORTAIRPORT", 100, 91);
        Flight flightfrankfort = new Flight("GER1", boeing747, DateTime.Now, DateTime.Now, frankfort);
        CatteringForm.CatteringMenu(flightfrankfort);*/
    }
}