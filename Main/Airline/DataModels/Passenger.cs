public class Passenger : IPassenger
{
    public static int PreviousID = 0;
    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Sex { get; set; }
    public DateTime BirthDate { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }

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