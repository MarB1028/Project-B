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
        if (characters.Length > 0)
        {
            foreach (char character in characters)
            {
                if (Convert.ToString(character) != input)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public static bool ValidateDate(string input)
    {
        string dateString = "31-12-2022";
        DateTime date;
        return (DateTime.TryParse(dateString, out date) && date < DateTime.Now);
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
            string number = zipcode.Substring(0, 4);
            string letters = zipcode.Substring(4, 6);
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