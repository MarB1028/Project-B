using Newtonsoft.Json;
class CheckSeatAvailability
{
    public Flight Flight;
    public Dictionary<string, BookTicket> Seats = new Dictionary<string, BookTicket> ();

    public CheckSeatAvailability(Flight flight)
    {
        Flight = flight;
    }
    // Checkt of de stoel vrij is.
    
    public BookTicket GetBookTicket(string SeatNumber) {
        //Haalt de lijst met info uit de jsonfile
        DeserialzeTicketsJson ticketsJson = new DeserialzeTicketsJson();
        ticketsJson.flight = Flight;

        //loopt door de lijst en checkt naar dezelfde seatnumber
        foreach(BookTicket bt in ticketsJson.GetList()) 
        {
            if (bt.Ticket.Seat.SeatNumber == SeatNumber) 
            {
                return bt;
                }
                
        }
        return null;
    }
    public bool IsSeatTaken(string SeatNumber)
    {
        //Haalt de lijst met info uit de jsonfile
        DeserialzeTicketsJson ticketsJson = new DeserialzeTicketsJson();
        ticketsJson.flight = Flight;
 
        //loopt door de lijst en checkt naar dezelfde seatnumber
        foreach(BookTicket bt in ticketsJson.GetList()) 
        {
            if (bt.Ticket.Seat.SeatNumber == SeatNumber) 
            {
                return bt.Booked;
                }
                
        }
        //Wanneer de seat niet bestaat
        Console.WriteLine("Seat not found");
        return false;
    }

    // Print de beschikbare stoelen.
    public void AvailableSeats()
    {
        //Seatinchart weergeeft het totale overzicht
        List<string> SeatingChart = new List<string> ();
        //hier tel ik de aantal rijen
        int TotalRows = Flight.Airplane.FirstClassSeat + Flight.Airplane.PremiumSeat + Flight.Airplane.ExtraSpace + Flight.Airplane.EconomySeat;
        int firstclass = Flight.Airplane.FirstClassSeat;
        int premium = Flight.Airplane.PremiumSeat;
        int economy = Flight.Airplane.EconomySeat;
        int ExtraSpace = Flight.Airplane.ExtraSpace;
       
        //de volgende 2 variables zijn voor het koppelen met de BO nummers
        int seatint = 1;
        string realseatnum = "";

        //Loop door het aantal rijen
        for (int row = 0; row < TotalRows; row++) 
        {
            //Kopje per klas
            Console.ForegroundColor = ConsoleColor.White;
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
            
            //In seatsrow komen de 6 stoelen te staan. Seat geeft de stoelnaam aan
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
                
                //Hier koppel ik de stoel aan het echte BO nummer
                realseatnum = "BO-" + seatint.ToString();
                seatint++;

                
            
                //Stoelen toevoegen aan totale overzicht
                //Geeft true/false terug, XXX komt er wanneer de stoel bezet is.-
                if (IsSeatTaken(realseatnum)) {
                    seatsrow += "XXX  ";
                }
                else {
                    if (row + 1 < 10) 
                    {
                        seatsrow += "0" + (row + 1).ToString() + seat + "  ";
                        //Hier voeg ik de stoel gekoppeld aan de bookticket toe aan een dictionary
                        Seats.Add("0" + (row + 1).ToString() + seat, GetBookTicket(realseatnum));
                    }
                    else
                    {
                        seatsrow += (row + 1).ToString() + seat + "  ";
                        //Hier voeg ik de stoel gekoppeld aan de bookticket toe aan een dictionary
                        Seats.Add((row + 1).ToString() + seat, GetBookTicket(realseatnum));
                    }
                    
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
            for (int x = 0; x < row.Length; x++)
                {
                    if (row[x] == 'X') {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (row[x] == ' ' || row[x] == '|' || row[x] == '-') {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.Write(row[x]);
                    if (x == row.Length - 1)
                    {
                        Console.Write("\n");
                        continue;
                    }
                }
        }
        BookSeat();
    }

    // Een beschikbare stoel boeken.
    public void BookSeat()
    {
        //Hier vult de user in hoeveel stoelen, maar in de toekomst moet dit nog veranderen. 
        //De user geeft namelijk al veel eerder aan hoeveel tickets hij/zij wilt boeken.
        Console.WriteLine("Hoeveel stoelen wilt u boeken?\n->");
        int amount = Convert.ToInt32(Console.ReadLine());
        while (amount < 0) {
            Console.WriteLine("Give a positive number.");
            amount = Convert.ToInt32(Console.ReadLine());
        }


        //TODO: de geboekte tickets moeten worden toegevoeg aan account.
        //In de geboekte ticket wordt nu de ticket met stoel ingevuld
        for (int x = 0; x < amount; x++) {
            bool y = true;
            while (y){
                Console.WriteLine($"Ticket {x+1}:\nVoer stoelnummer in (Bijvoorbeeld 01C/11B):\n->");
                string SeatNumber = Console.ReadLine().ToUpper();
                //Checkt of de stoel uberhaupt bestaat
                if (Seats.ContainsKey(SeatNumber) == false) {
                    Console.WriteLine("Seat number does not exist! try again");
                }
                //Checkt of de stoel al geboekt is
                else if (Seats[SeatNumber].Booked == true) {
                    Console.WriteLine("This seat has already been booked!\nChoose another");
                }

                else {
                    BookTicket bookticket = Seats[SeatNumber];
                    Console.WriteLine($"Je hebt stoelnummer {SeatNumber} ({bookticket.Ticket.Seat.SeatNumber}) gekozen in de {bookticket.Ticket.Seat.SeatType} klas.");
                    //TODO: De bookedticket moet nu naar true gezet worden met alle informatie van de passenger
                    y = false;
                }
            }
        }
        //eventueel:
        Console.WriteLine("Continue to payment.");
    
    }

}