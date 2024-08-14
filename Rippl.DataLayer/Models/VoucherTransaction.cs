namespace Rippl.DataLayer.Models
{
    public class VoucherTransaction
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime PurchaseTime { get; set; }
        public string Status { get; set; } = string.Empty;
        public ICollection<VoucherTransactionDetail> TransactionDetails { get; set; } = new List<VoucherTransactionDetail>();
    }
}
