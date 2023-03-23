using Newtonsoft.Json;
class CheckSeatAvailability
{
    public Flight Flight;

    public CheckSeatAvailability(Flight flight)
    {
        Flight = flight;
    }
    // Checkt of de stoel vrij is.
    public void IsSeatTaken(string SeatNumber)
    {
        //List<BookTicket> ReadAccountsFromJSON()
    
        // if (!File.Exists($"{Flight.Airplane.Name};PLANEID{Flight.Airplane.AirplaneId};{Flight.FlightId}.json"))
        // {
        //     return new List<BookTicket>();
        // }

        // string json = File.ReadAllText($"{Flight.Airplane.Name};PLANEID{Flight.Airplane.AirplaneId};{Flight.FlightId}.json");
        // List<BookTicket> bookTickets = JsonConvert.DeserializeObject<List<BookTicket>>(json);
        // foreach (BookTicket bt in bookTickets) {
        //     Console.WriteLine(bt);
        // }
        // return bookTickets ?? new List<BookTicket>();
   
        string file = $"{Flight.Airplane.Name};PLANEID{Flight.Airplane.AirplaneId};{Flight.FlightId}.json";
        StreamReader reader = new(file);
        string File2Json = reader.ReadToEnd();
        List<BookTicket> bookTickets = JsonConvert.DeserializeObject<List<BookTicket>>(file)!;
        reader.Close();

        foreach (BookTicket bt in bookTickets) {
            Console.WriteLine(bt);
        }
    }

    // Print de beschikbare stoelen.
    public void AvailableSeats()
    {
        List<string> SeatingChart = new List<string> ();
        int TotalRows = Flight.Airplane.FirstClassSeat + Flight.Airplane.PremiumSeat + Flight.Airplane.ExtraSpace + Flight.Airplane.EconomySeat;
        int firstclass = Flight.Airplane.FirstClassSeat;
        int premium = Flight.Airplane.PremiumSeat;
        int economy = Flight.Airplane.EconomySeat;
        int ExtraSpace = Flight.Airplane.ExtraSpace;
        int Rows = 0;
        //Aantal rijen bepalen
       
        for (int row = 0; row < TotalRows; row++) 
        {
            
            if (row == 0) {
                
                SeatingChart.Add(" |------------First Class-------------|");
            }
            else if (row == firstclass ) {
                SeatingChart.Add(" |-----------Premium Class------------|");
            }
            else if (row == premium + firstclass ) {
                SeatingChart.Add(" |-----------Economy Class------------|");
            }
            else if (row == economy + premium + firstclass ) {
                SeatingChart.Add(" |------------Extra Space-------------|");
            }
            

            string seatsrow = " ";
            string seat = "";
            seatsrow += "| ";
            for (int col = 0; col < 6; col++) //
            {  
                if (col == 0) {
                    seat = "A";
                    
                }
                else if (col == 1) {
                    seat = "B";
                }
                else if (col == 2) {
                    seat = "C";
                }
                else if (col == 3) {
                    seat = "D";
                }
                else if (col == 4) {
                    seat = "E";
                }
                else {
                    seat = "F";
                }

                //Stoelen toevoegen aan totale overzicht
                //Dit moet uiteindelijk alleen gebeuren wanneer een stoel nog vrij is, anders moet er XXX staan.
                if (row + 1 < 10) 
                {
                    seatsrow += "0" + (row + 1).ToString() + seat + "  ";
                }
                else
                {
                    seatsrow += (row + 1).ToString() + seat + "  ";
                }
                
                //Voegt ruimte in het midden toe.
                seatsrow += (col == 2 ? "    " : "");
                seatsrow += (col == 5 ? " |" : "");
            }
            SeatingChart.Add(seatsrow);
            if (row == TotalRows-1) {
                SeatingChart.Add(" |------------------------------------|");
            }
            
        }
        foreach (string row in SeatingChart)
        {
            Console.WriteLine(row);
        }
    }

}