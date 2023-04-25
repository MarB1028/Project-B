class Program
{
    public static void Main()
    {
        // [Maria] De entrypoint van het programma, vluchten laten zien en inloggen
        /*Menu.StartScreen();*/

        // CODE TEST [Jiajun]
        //Airplane boeing747 = new Airplane("BOEING747", "BO", 1, 4, 5, 6, 2);
        // [Marie-Claire] Het process van de ticket boeken
        /*Airplane boeing747 = new Airplane("BOEING747", "BO", 1, 4, 5, 6, 2);

        Destination frankfort = new Destination("GER", "FRA", "FRANKFORTAIRPORT", 100, 2);
        Destination mannenheim = new Destination("GER", "MAN", "MANNENHEIMAIRPORT", 100, 2);
        Flight flightfrankfort = new Flight("GER1", boeing747, DateTime.Now, DateTime.Now, frankfort);
        Flight flightmannenheim = new Flight("GER2", boeing747, DateTime.Now, DateTime.Now, mannenheim);

        // MakeOverviewFlightJson.MakeOverviewJson(flightfrankfort);
        // MakeOverviewFlightJson.MakeOverviewJson(flightmannenheim);

        MakeTicketsForFlightJson.MakeTickets(flightfrankfort);
        MakeTicketsForFlightJson.MakeTickets(flightmannenheim);
        
        //BookTicket test = new BookTicket(new Ticket("Jiajun", "Li", flightmannenheim, FindObjectSeat.FindSeatObject(flightmannenheim, "BO-1"), "G18"));
        //DataTickets.WriteTicketToJson(flightmannenheim, test);

        // CODE TEST [Soufiane]
        /*PassengerForm.Form();*/

        // CODE TEST [Marissa]
        /*Login.LoginpageMessage();*/

        // CODE TEST [Marie-Claire]
        // Airplane boeing747 = new Airplane("BOEING747", "BO", 1, 4, 5, 6, 2);
        // Destination frankfort = new Destination("GER", "FRA", "FRANKFORTAIRPORT", 100, 2);
        // Flight flightfrankfort = new Flight("GER1", boeing747, DateTime.Now, DateTime.Now, frankfort);
        // CheckSeatAvailability checkSeatAvailability = new CheckSeatAvailability(flightfrankfort);
        // checkSeatAvailability.AvailableSeats();

        // [Marissa] Inchecken van de koffers en de prijzen uitrekenen
        /*Airplane boeing747 = new Airplane("BOEING747", "BO", 1, 4, 5, 6, 2);
        Destination frankfort = new Destination("GERMANY", "FRANKFURT", "(GER)", "FRANKFORTAIRPORT", 100, 2, "On Schedule");
        Flight flightfrankfort = new Flight(1, "GER1", "Day", boeing747, DateTime.Now, DateTime.Now, frankfort, 100);
        Passenger passenger = new Passenger("Jiajun", "Li", "M", DateTime.Now, "Poepstraat 10 3119AD", "0640636337");

        BookTicket test = new BookTicket(new Ticket(passenger, flightfrankfort, FindObjectSeat.FindSeatObject(flightfrankfort, "BO-1"), "G18"));
        CalculateTotalCosts.tickets.Add(test);

        Luggage.LuggageInfo();*/

        // [Jiajun] Het selecteren van de Cattering en de prijzen uitrekenen
        /*Airplane boeing747 = new Airplane("BOEING747", "BO", 1, 4, 5, 6, 2);
        Destination frankfort = new Destination("GERMANY", "FRANKFURT", "(GER)", "FRANKFORTAIRPORT", 100, 3, "On Schedule");
        Flight flightfrankfort = new Flight(1, "GER1", "Day", boeing747, DateTime.Now, DateTime.Now, frankfort, 100);
        CatteringForm.Cattering(flightfrankfort);*/
        Menu.StartScreen();
    }
}