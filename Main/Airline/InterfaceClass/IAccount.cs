public interface IAccount
{
    int ID { get; set; }
    bool LoggedIn { get; set; }
    string Email { get; set; }
    List<BookTicket> BoughtTickets { get; set; }
    List<Voucher> Vouchers { get; set; }
    string Password { get; set; }
}