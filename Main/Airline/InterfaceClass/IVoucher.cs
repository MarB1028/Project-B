public interface IVoucher
{
    string VoucherCode { get; set; }
    DateTime Cancellationdate { get; set; }
    DateTime Expirationdate { get; set; }
    string Flightinfo { get; set; }
    double Price { get; set; }
}