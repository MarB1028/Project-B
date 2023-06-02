static class PassengerForm
{
     public static List<Passenger> passengers = new List<Passenger>();

    // Dit controleert of de validatie true of false is en herhaalt de vraag als het false is
    public static string Loop(string field, Func<string, bool> validation, string error) // Func<string, bool> validation is de method uit de validation class dat wordt meegegeven
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
    public static void Form(Flight flight, List<BookTicket> tickets)
    {
        // Account acc = null;

        for (int i = 0; i < tickets.Count(); i++)
        {
            //Hier worden alle variabelen gedeclareerd die vervolgens velden worden voor het object
            Passenger passenger0;
            string firstName;
            string lastName;
            string sex;
            DateTime birthDate;
            string birthDateString;
            string address;
            string phoneNumber;
            do
            {
                // Intro zin
                Console.WriteLine("Please enter the personal information below:");
                Console.Write($"Ticket {i + 1}: ");
                Console.WriteLine($"Ticket {i + 1}: ");

                if (i == 0)
                {
                    Console.WriteLine("(Main booker)");
                }
                Console.WriteLine();

                // Naam
                firstName = Loop("First name", x => ValidateInput.IsAlpha(x, "'-"), "Invalid first name");
                lastName = Loop("Last name", x => ValidateInput.IsAlpha(x, "- "), "Invalid last name");

                // Geslacht
                sex = Loop("Gender(M/F/X)", x => ValidateInput.IsMatch(x, "MFX"), "Invalid input. Enter your gender (M for male, F for female or X for neither).");

                // Geboortedatum
                birthDateString = Loop("Date of Birth (DD-MM-YYYY)", x => ValidateInput.ValidateDate(x), "Invalid input. Please enter your date of birth in the correct format (DD-MM-YYYY).");
                birthDate = Convert.ToDateTime(birthDateString);

                //Adres
                Console.WriteLine("Street name: ");
                string street = Console.ReadLine();
                string housenumber = Loop("Housenumber", x => ValidateInput.IsNumber(x), "Invalid housenumber. Please enter a valid housenumber containing numbers only [0-9].");
                string addition = Loop("Addition (Press ENTER if this does not apply)", x => ValidateInput.ValidateAddition(x), "Please enter a valid housenumber addition or press ENTER if this does not apply.");
            
                string zipcode = Loop("Zipcode(1234AB)", x => ValidateInput.ValidateZipCode(x), "Invalid zipcode. Please enter your zipcode in the correct format (1234AB).");
                string city = Loop("City", x => ValidateInput.IsAlpha(x), "Invalid city. Please enter a valid city");
                address = $"{street} {housenumber}{addition} {zipcode} {city}";

                //Telefoonnummer
                if (i == 0)
                {
                    phoneNumber = Loop("Phonenumber", x => ValidateInput.ValidatePhoneNumber(x), "Invalid phonenumber. Please enter a valid phonenumber starting with either 06 or +316 followed by 8 numbers.");
                }
                else
                {
                    phoneNumber = "Empty";
                }
                passenger0 = new Passenger(firstName, lastName, sex, birthDate, address, phoneNumber);


            }
            while (Overview(passenger0) == false);
            //Hier voeg je de informatie van de passenger toe aan de bookticket
            tickets[i].Ticket.Passenger = passenger0;
            //Hier wordt de bookticket opnieuw naar de json file geschreven
            DataTickets.WriteTicketToJson(flight, tickets[i]);
            passengers.Add(passenger0);
        }
        Luggage.LuggageInfo(tickets);
    }

    // Print een overview van het formulier en vraagt de gebruiker of het klopt of dat hij/zij het opnieuw wil invullen
    public static bool Overview(Passenger passenger)
    {
        Console.WriteLine("Personal information: ");
        Console.WriteLine("");
        Console.WriteLine($"First Name: {passenger.FirstName}");
        Console.WriteLine($"Last name: {passenger.LastName}");
        Console.WriteLine($"Sex: {passenger.Sex}");
        Console.WriteLine($"Date of Birth: {passenger.BirthDate.ToString("dd-MM-yyyy")}");
        Console.WriteLine($"Address: {passenger.Address}");
        if (passenger.PhoneNumber != "Empty")
        {
            Console.WriteLine($"Phonenumber: {passenger.PhoneNumber}");
        }
        Console.WriteLine("\n");

        string input;
        Console.WriteLine("Is this information Correct (Y/N)?");
        input = Console.ReadLine();
        while (ValidateInput.IsMatch(input, "YN") == false)
        {
            Console.WriteLine("Invalid input. Please enter Y if the information is correct and N if the information is incorrect.");
            input = Console.ReadLine();
        }
        if (input.ToUpper() == "Y")
        {
            Console.WriteLine();
            Console.Write("Press ENTER to continue...");
            Console.ReadLine();

            //DataTickets.WriteTicketToJson()
            return true;
        }
        else
        {
            return false;
        }
    }
}