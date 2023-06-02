public class Passenger
{
    public static int PreviousID = 0;
    public int ID;
    public string FirstName;
    public string LastName;
    public string Sex;
    public DateTime BirthDate;
    public string Address;
    public string PhoneNumber;

    public Passenger(string firstname, string lastname, string sex, DateTime birthDate, string address, string phoneNumber)
    {
        ID = PreviousID + 1;
        PreviousID = ID;
        FirstName = firstname;
        LastName = lastname;
        Sex = sex;
        BirthDate = birthDate;
        Address = address;
        PhoneNumber = phoneNumber;
    }
}