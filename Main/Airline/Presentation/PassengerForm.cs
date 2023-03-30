public class PassengerForm
{  
    // Dit controleert of de validatie true of false is en herhaalt de vraag als het false is
    public string Loop(string field, Func<string, bool> validation, string error) // Func<string, bool> validation is de method uit de validation class dat wordt meegegeven
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
        List<Passenger> passengers = new List<Passenger> ();
        // Dit bepaalt hoeveel formulieren er moeten worden gegenereerd
        // In de volgende sprint wordt dit in een andere fase van het boekingsproces gezet.
        int amount = Convert.ToInt32(Loop("Kies het aantal tickets", x => ValidateInput.IsNumber(x), "Voer een geldig getal in."));

        for (int i = 0; i < amount; i ++)
        {
            //Hier worden alle variabelen gedeclareerd die vervolgens velden worden voor het object
            Passenger passenger0;
            string surName;
            string lastName;
            string sex;
            DateTime birthDate;
            string birthDateString;
            string adress;
            string phoneNumber;
            do
            {
            // Intro zin
            Console.WriteLine($"Ticket {i + 1}: ");
            Console.WriteLine("Voer de persoonlijke gegevens in:");

            // Naam
            surName = Loop("Voornaam", x => ValidateInput.IsAlpha(x, "'-"), "Ongeldige voornaam.");
            lastName = Loop("Achternaam", x => ValidateInput.IsAlpha(x, " "), "Ongeldige achternaam.");

            // Geslacht
            sex = Loop("Geslacht(M/V)", x => ValidateInput.IsMatch(x, "MV"), "Ongeldige invoer. Voer uw geslacht in (M voor een man en V voor een vrouw).");

            // Geboortedatum
            birthDateString = Loop("Geboortedatum (DD-MM-JJJJ)", x => ValidateInput.ValidateDate(x), "Ongeldige geboortedatum. Voer een geldige geboortedatum in het juiste formaat (DD-MM-JJJJ).");
            birthDate = Convert.ToDateTime(birthDateString);

            //Adres
            string street = Loop("Straatnaam", x => ValidateInput.IsAlpha(x, " "), "Ongeldige straatnaam. Een straatnaam bestaat uitsluitend uit letters.");
            string housenumber = Loop("Huisnummer", x => ValidateInput.IsNumber(x), "Ongeldige huisnummer. Voer een geldig huisnummer in dat uitsluitend [0=9] bevat.");
            string addition =  Loop("Toevoeging(Druk op ENTER als dit niet van toepassing is)", x => ValidateInput.IsAlpha(x), "Voer een geldige huisnummer toevoeging in.");
            string zipcode = Loop("Postcode(1234AB)", x =>ValidateInput.ValidateZipCode(x), "Ongeldige postcode. Voer een geldige geboortedatum in het juiste formaat (1234AB).");
            string city = Loop("Plaats", x => ValidateInput.IsAlpha(x), "Ongeldige plaats. Voer een geldige plaats in");
            adress = $"{street} {housenumber} {addition} {zipcode} {city}";

            //Telefoonnummer
            phoneNumber = Loop("Telefoonnummer", x => ValidateInput.IsNumber(x), "Ongeldige Telefoonnummer. Voer een geldige telefoonnummer in.");
            passenger0 = new Passenger(surName, lastName, sex, birthDate, adress, phoneNumber);

            
            }
            while (Overview(passenger0) == false);
            passengers.Add(passenger0);
        }
    }

    // Print een overview van het formulier en vraagt de gebruiker of het klopt of dat hij/zij het opnieuw wil invullen
    public bool Overview(Passenger passenger)
    {
        Console.WriteLine("De gegevens: ");
        Console.WriteLine("/n");
        Console.WriteLine($"\nVoornaam: {passenger.Surname}");
        Console.WriteLine($"Achternaam: {passenger.Lastname}");
        Console.WriteLine($"Geslacht: {passenger.Sex}");
        Console.WriteLine($"Geboortedatum: {passenger.BirthDate.ToString("dd-MM-yyyy")}");
        Console.WriteLine($"Adres: {passenger.Adress}");
        Console.WriteLine($"Telefoonnummer: {passenger.PhoneNumber}");
        Console.WriteLine("/n");

        string input;
            Console.WriteLine("Kloppen deze gegevens? (J/N)");
            input =  Console.ReadLine();
        while (ValidateInput.IsMatch(input, "JN") == false)
        {
            Console.WriteLine("Ongeldige invoer. Voer 'J' in als de gegevens kloppen en 'N' als de gegevens niet kloppen.");
            input = Console.ReadLine();
        }
        if (input.ToUpper() == "J")
        {
            Console.Clear();
            return true;
        }
        else
        {
            return false;
        }
}
}
