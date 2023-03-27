using System.Globalization;
public static class ValidateInput
{
    public static bool IsAlpha(string input, string exception = null)
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

    public static bool ValidateDate(string input)
    {
        string dateString = input;
        DateTime date;
        return (DateTime.TryParseExact(dateString, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date) && date < DateTime.Now);
    }

    public static bool ValidateLength(string input, int length)
    {
        string inputNoSpace = input.Replace(" ", "");
        return (inputNoSpace.Length == length);
    }


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