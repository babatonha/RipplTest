using Rippl.DataLayer.Models;

namespace Rippl.BusinessLayer.Interfaces.Services
{
    public interface ICartService
    {
        Task<HttpResponseMessage> AddToCart(Cart cart);
        Task<HttpResponseMessage> Checkout(Cart cart);
    }
}
