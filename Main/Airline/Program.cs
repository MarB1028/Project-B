class Program
{
    public static void Main()
    {
        // Main
        // Objects maken

        // 1. Je kiest eerst een vliegtuig uit. Ik kies bijvoorbeeld de vliegtuig boeing747
        // Dan geef je de carrier ID mee. Dat is hierzo BO en wordt later gebruik gemaakt voor de stoelen.
        // Na het aangeven van een de carrierid geef je de Airplane ID mee. Dat is hierzo 1.
        // Daarna kies je de aantal stoelen voor FirstClass(10), Premium(20), Economy(40) en Regular(100).
        // Niet alle stoelen staan hierin. Ik heb alleen een paar gekozen. 
        Airplane boeing747 = new Airplane("BOEING747", "BO", 1, 10, 20, 40, 100);
        
        // 2. Je kiest een bestemming voor het vliegtuig. Voor dit voorbeeld doe ik duitsland.
        // Je geeft eerst het vlucht ID dat is hierzo GER1. Daarna geef je het vliegtuig object, boeing747.
        // Dan geef je de boarding time and arrival time
        // Als laatste geef je het land en de bestemming.
        Flight germany = new Flight("GER1", boeing747, DateTime.Now, DateTime.Now, "Germany", "Frankfort", 1.02);
        
        // 3. Je maakt tickets aan voor het vlucht, het wordt automatisch gedaan.
        MakeTicketsForFlight flightgermany = new MakeTicketsForFlight(germany);
        flightgermany.MakeTickets();
    }
}