namespace Rippl.DataLayer.Models
{
    public class Voucher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UniqueCode { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
