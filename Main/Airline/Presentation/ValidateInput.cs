using System.Globalization;
public static class ValidateInput
{
    //Elke method returnt een bool (valid of invalid)

    //Controleert of de input uit letters bestaat 
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

    // Controleert of een string uit alleen nummers bestaat
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

    // Controleert of input gelijk is aan een van de characters in character (vb. V en MmVv => true)
    public static bool ValidateMatch(string input, string characters)
    {
        if (input.Length == 1)
        {
            foreach (char character in characters)
            {
                if (Convert.ToString(character) == input)
                {
                    return true;
                }
            }
            return false;
        }
        return false;
    }

    //Controleert of een datum de juiste format heeft en of het in het verleden is
    public static bool ValidateDate(string input)
    {
        string dateString = input;
        DateTime date;
        bool checkDate = true;
        checkDate = DateTime.TryParseExact(dateString, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
        if (checkDate == true)
        {
            if (date > DateTime.Now)
            {
                checkDate = false;
            }
        }
        return checkDate;
    }

    // Controleert de lengte van een string
    public static bool ValidateLength(string input, int length)
    {
        string inputNoSpace = input.Replace(" ", "");
        return (inputNoSpace.Length == length);
    }


    // Dit haalt alle spaties weg en controleert of de postcode in het juiste formaat is (1234AB)
    public static bool ValidateZipCode(string input)
    {
        if (ValidateLength(input, 6) == true)
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
}