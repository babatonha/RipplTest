using Rippl.DataLayer.Models;

namespace Rippl.BusinessLayer.Interfaces.External
{
    public interface IVoucherProviderService
    {
        Task<HttpResponseMessage> ListVouchers();
        Task<HttpResponseMessage> DetailVoucher(int id);
        Task<HttpResponseMessage> CreateCart(Cart cart);
        Task<HttpResponseMessage> UpdateCart(Cart cart);
        Task<HttpResponseMessage> Checkout(Cart cart);
    }
}
