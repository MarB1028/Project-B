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

    public void Form()
    {
        foreach (string ticket in TicketList)
        {

            do
            {
            // Intro zin
            Console.WriteLine(ticket);
            Console.WriteLine("Voer de persoonlijke gegevens in:");

            // Naam
            SurName = Loop("Voornaam", x => ValidateInput.IsAlpha(x, " "), "Ongeldige voornaam. Een voornaam bestaat uitsluitend uit letters.");
            LastName = Loop("Achternaam", x => ValidateInput.IsAlpha(x, " "), "Ongeldige achternaam. Een achternaam bestaat uitsluitend uit letters.");

            // Geslacht
            Sex = Loop("Geslacht(M/V)", x => ValidateInput.ValidateMatch(x, "MmVv"), "Ongeldige invoer. Voer uw geslacht in (M voor een man en V voor een vrouw).");

            // Geboortedatum
            string birthDate = Loop("Geboortedatum", x => ValidateInput.ValidateDate(x), "Ongeldige geboortedatum. Voer een geldige geboortedatum in het juiste formaat (DD-MM-JJJJ).");
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
    }

    public bool Overview()
    {
        Console.WriteLine($"\nVoornaam: {SurName}");
        Console.WriteLine($"Achternaam: {LastName}");
        Console.WriteLine($"Geslacht: {Sex}");
        Console.WriteLine($"Geboortedatum: {BirthDate}");
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

    public string Loop(string field, Func<string, bool> validation, string error)
    {
        Console.WriteLine($"{field}: ");
        string input = Console.ReadLine();

        bool checkInput = validation(input);
        while (checkInput)
        {
            Console.WriteLine(error);
            Console.WriteLine($"{field}: ");
            input = Console.ReadLine();
            checkInput = validation(input);
        }
        return input;
    }
}
