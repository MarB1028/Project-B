public class PassengerForm
{
    public List<string> TicketList;
    public List<Passenger> Passengers;
    public string SurName;
    public string LastName;
    public string Sex;
    public DateTime BirthDate;
    public string Adress;
    public string PhoneNumber;

    public PassengerForm(List<string> ticketList)
    {
        TicketList = ticketList;
        Passengers = new List<Passenger> ();
    }
    
    // Dit controleert of de validatie true of false is en herhaalt de vraag als het false is
    public string Loop(string field, Func<string, bool> validation, string error)
    {
        Console.WriteLine($"{field}: ");
        string input = Console.ReadLine();

        bool checkInput = validation(input);
        while (checkInput == false)
        {
            Console.WriteLine(error);
            Console.WriteLine($"{field}: ");
            input = Console.ReadLine();
            checkInput = validation(input);
        }
        return input;
}

    //Hier wordt het formulier gegenereerd
    public void Form()
    {
        // Dit bepaalt hoeveel formulieren er moeten worden gegenereerd
        int amount = Convert.ToInt32(Loop("Kies het aantal tickets", x => ValidateInput.IsNumber(x), "Voer een geldig getal in."));

        for (int i = 0; i < amount; i ++)
        {
            do
            {
            // Intro zin
            Console.WriteLine($"Ticket {i + 1}: ");
            Console.WriteLine("Voer de persoonlijke gegevens in:");

            // Naam
            SurName = Loop("Voornaam", x => ValidateInput.IsAlpha(x, "'-"), "Ongeldige voornaam.");
            LastName = Loop("Achternaam", x => ValidateInput.IsAlpha(x, " "), "Ongeldige achternaam.");

            // Geslacht
            Sex = Loop("Geslacht(M/V)", x => ValidateInput.ValidateMatch(x, "MmVv"), "Ongeldige invoer. Voer uw geslacht in (M voor een man en V voor een vrouw).");

            // Geboortedatum
            string birthDate = Loop("Geboortedatum (DD-MM-JJJJ)", x => ValidateInput.ValidateDate(x), "Ongeldige geboortedatum. Voer een geldige geboortedatum in het juiste formaat (DD-MM-JJJJ).");
            BirthDate = Convert.ToDateTime(birthDate);

            //Adres
            string street = Loop("Straatnaam", x => ValidateInput.IsAlpha(x, " "), "Ongeldige straatnaam. Een straatnaam bestaat uitsluitend uit letters.");
            string housenumber = Loop("Huisnummer", x => ValidateInput.IsNumber(x), "Ongeldige huisnummer. Voer een geldig huisnummer in dat uitsluitend [0=9] bevat.");
            string addition =  Loop("Toevoeging(Druk op ENTER als dit niet van toepassing is)", x => ValidateInput.IsAlpha(x), "Voer een geldige huisnummer toevoeging in.");
            string zipcode = Loop("Postcode(1234AB)", x =>ValidateInput.ValidateZipCode(x), "Ongeldige postcode. Voer een geldige geboortedatum in het juiste formaat (1234AB).");
            string city = Loop("Plaats", x => ValidateInput.IsAlpha(x), "Ongeldige plaats. Voer een geldige plaats in");
            Adress = $"{street} {housenumber} {addition} {zipcode} {city}";

            //Telefoonnummer
            PhoneNumber = Loop("Telefoonnummer", x => ValidateInput.IsNumber(x), "Ongeldige Telefoonnummer. Voer een geldige telefoonnummer in.");

            
            }
            while (Overview() == false);
            Passengers.Add(new Passenger(SurName, LastName, Sex, BirthDate, Adress, PhoneNumber));
        }
        PassengerToJSON passengerToJSON = new PassengerToJSON();
        passengerToJSON.WritePassengerToJSON(Passengers);
    }

    // Print een overview van het formulier en vraagt de gebruiker of het klopt of dat hij/zij het opnieuw wil invullen
    public bool Overview()
    {
        Console.WriteLine($"\nVoornaam: {SurName}");
        Console.WriteLine($"Achternaam: {LastName}");
        Console.WriteLine($"Geslacht: {Sex}");
        Console.WriteLine($"Geboortedatum: {BirthDate.ToString("dd-MM-yyyy")}");
        Console.WriteLine($"Adres: {Adress}");
        Console.WriteLine($"Telefoonnummer: {PhoneNumber}");

        string input;
            Console.WriteLine("Kloppen deze gegevens? (J/N)");
            input =  Console.ReadLine();
        while (ValidateInput.ValidateMatch(input, "JjNn") == false)
        {
            Console.WriteLine("Ongeldige invoer. Voer 'J' in als de gegevens kloppen en 'N' als de gegevens niet kloppen.");
            input = Console.ReadLine();
        }
        if (input.ToUpper() == "J")
        {
            return true;
        }
        else
        {
            return false;
        }
}
}
