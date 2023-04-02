using System.Globalization;
public static class ValidateInput
{
    //Elke method returnt een bool (true=valid of flase=invalid)
    //De volgende vijf methods controleren input op algemene criteria
    //Controleert of de input uitsluitend uit letters bestaat 
    public static bool IsAlpha(string input, string exception = null) // Je kan uitzonderingen meegeven (exception = "-" maakt marie-claire valid)
    {
        foreach (char character in input)
        {
            if (char.IsLetter(character) == false && Convert.ToString(character) != exception)
            {
                return false;
            }
        }
        return true;
    }

    // Controleert of een string uitsluitend uit positieve nummers bestaat
    public static bool IsNumber(string input)
    {
        foreach (char character in input)
        {
            int number = 0;
            if (int.TryParse(Convert.ToString(character), out number) == false && number >= 0)
            {
                return false;
            }
        }
        return true;
    }

    // Controleert of een characterinput gelijk is aan de gevraagde characters (vb. v en MV => true, v en JM => false)
    public static bool IsMatch(string input, string characters)
    {
        if (input.Length == 1)
        {
            foreach (char character in characters)
            {
                if (Convert.ToString(character) == input.ToUpper())
                {
                    return true;
                }
            }
            return false;
        }
        return false;
    }

    //Controleert of de lengte van een string gelijk is aan een getal
    public static bool IsLength(string input, int length)
    {
        string inputNoSpace = input.Replace(" ", ""); //Spaties worden genegeerd
        return (inputNoSpace.Length == length);
    }

    // Dit is een overload die controleert of de lengte van een string in een bepaalde range zit
    public static bool IsLength(string input, int min, int max)
    {
        string inputNoSpace = input.Replace(" ", "");
        return (inputNoSpace.Length >= min && inputNoSpace.Length <= max);
    }

    //De volgende drie methods controleren methods op specifieke criteria

    //Controleert of een datum de juiste format heeft (dd-mm-jjjj) en of het in het verleden is (01 en 1 zijn beide valid dagen/maanden)
    public static bool ValidateDate(string input)
    {
        string dateString = input;
        DateTime date;
        bool checkDate = true;
        checkDate = DateTime.TryParseExact(dateString, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date); // InvariantCulture bevestigt dat dd-mm-jjjj gebruikt moet worden en niet de formaat van de gebruikers locatie
        if (checkDate == true)
        {
            if (date > DateTime.Now)
            {
                checkDate = false;
            }
        }
        return checkDate;
    }



    // Dit haalt alle spaties weg en controleert of de postcode in het juiste formaat is (1234AB)
    public static bool ValidateZipCode(string input)
    {
        if (IsLength(input, 6) == true)
        {
            string zipcode = input.Replace(" ", "");
            string number = $"{zipcode[0]}{zipcode[1]}{zipcode[2]}{zipcode[3]}";
            string letters = $"{zipcode[4]}{zipcode[5]}";
            if (IsNumber(number) == true && IsAlpha(letters) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    //Controleert of het telefoonnummer aan de de juiste criteria voldoet
    public static bool ValidatePhoneNumber(string input)
    {
        string phoneNumber = input.Replace(" ", "");
        if (phoneNumber.StartsWith("+316"))
        {
            phoneNumber.Remove(0, 3);
        }
        else if (phoneNumber.StartsWith("06"))
        {
            phoneNumber.Remove(0, 2);
        }
        else
        {
            return false;
        }
        return (IsNumber(phoneNumber) && (IsLength(phoneNumber, 8)));
    }

    // Dit checkt de leeftijd van een persoon en berekent het percentage dat de persoon moet betalen op basis van leeftijd 
    // Baby's t/m 3 jaar => 0
    // van 4 t/m 12 jaar => 0.35
    // van 13 t/m 17 jaar => 0.65
    // 18+ => 1
    public static double GetAgeRate(DateTime birthDate)
    {
        int age = DateTime.Today.Year - birthDate.Year;
        switch (age)
        {
            case >= 0 and <= 3:
                return 0;
            case >= 4 and <= 12:
                return 0.35;
            case >= 13 and <= 17:
                return 0.65;
            case >= 18:
                return 1;
            default:
                return 0;
        }
    }
}