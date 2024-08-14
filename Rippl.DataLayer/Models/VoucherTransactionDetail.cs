namespace Rippl.DataLayer.Models
{
    public class VoucherTransactionDetail : Voucher
    {
        public int VoucherTransactionId { get; set; }
        public VoucherTransaction VoucherTransaction { get; set; } = null!;
    }
}
