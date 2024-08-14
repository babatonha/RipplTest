using Rippl.DataLayer.Models;

namespace Rippl.BusinessLayer.Helpers
{
    public static class CartItemTransactionDetailMapper   // we can use Automapper as an option
    {
        public static List<VoucherTransactionDetail> MapCartItemsToTransactionDetails(List<CartItem> cartItems)
        {

            var transactionDetails = new List<VoucherTransactionDetail>();

            foreach (var item in cartItems)
            {
                var detail = new VoucherTransactionDetail();
                detail.Amount = item.Amount;
                detail.ExpiryDate = item.ExpiryDate;
                detail.Name = item.Name;
                detail.Description = item.Description;
                detail.UniqueCode = item.UniqueCode;

                transactionDetails.Add(detail);
            }

            return transactionDetails;
        }
    }
}
