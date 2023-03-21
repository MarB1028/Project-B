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
        StreamReader reader = new StreamReader($"C:\\Users\\marie\\OneDrive - Hogeschool Rotterdam\\Semester 2\\Project B\\Project-B\\Main\\Airline\\DataSources{Flight.Airplane.Name};PLANEID{Flight.Airplane.AirplaneId};{Flight.FlightId}.json"); 
        string jsonString = reader.ReadToEnd();
        reader.Close();
        //var fromjson = JsonConvert.DeserializeObject<double>(jsonString)!;
        Console.WriteLine(jsonString);
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
                SeatingChart.Add("First Class");
            }
            else if (row == firstclass ) {
                SeatingChart.Add("Premium Class");
            }
            else if (row == premium + firstclass ) {
                SeatingChart.Add("Economy Class");
            }
            else if (row == economy + premium + firstclass ) {
                SeatingChart.Add("Extra Space");
            }

            string seatsrow = " ";
            string seat = "";
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
            }
            SeatingChart.Add(seatsrow);
            
        }
        foreach (string row in SeatingChart)
        {
            Console.WriteLine(row);
        }
    }

}