using Rippl.DataLayer.Enums;
using Rippl.DataLayer.Models;

namespace Rippl.BusinessLayer.Helpers
{
    public static class CartToTransactionMapper
    {
        public static VoucherTransaction MapCartToVoucherTransaction(Cart cart)
        {
            return new VoucherTransaction
            {
                Amount = cart.TotalAmount,
                PurchaseTime = DateTime.Now,
                Status = TransactionStatus.Successful.ToString(),
                TransactionDetails = CartItemTransactionDetailMapper.MapCartItemsToTransactionDetails(cart.CartItems)
            };
        }
    }
}
