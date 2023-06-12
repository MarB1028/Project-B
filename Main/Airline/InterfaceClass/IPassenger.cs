public interface IPassenger
{
    int ID { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    string Sex { get; set; }
    DateTime BirthDate { get; set; }
    string Address { get; set; }
    string PhoneNumber { get; set; }
}