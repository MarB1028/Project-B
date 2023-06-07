public class Voucher
{
    public string VoucherCode;
    public DateTime Cancellationdate;
    public DateTime Expirationdate;
    public string Flightinfo;
    public double Price;

    public Voucher(string voucherCode, DateTime cancellationdate, DateTime expirationdate, string flightInfo, double price)
    {
        VoucherCode = voucherCode;
        Cancellationdate = cancellationdate;
        Expirationdate = expirationdate;
        Flightinfo = flightInfo;
        Price = price;
    }
}