public class Voucher : IVoucher
{
    public string VoucherCode { get; set; }
    public DateTime Cancellationdate { get; set; }
    public DateTime Expirationdate { get; set; }
    public string Flightinfo { get; set; }
    public double Price { get; set; }

    public Voucher(string voucherCode, DateTime cancellationdate, DateTime expirationdate, string flightInfo, double price)
    {
        VoucherCode = voucherCode;
        Cancellationdate = cancellationdate;
        Expirationdate = expirationdate;
        Flightinfo = flightInfo;
        Price = price;
    }
}