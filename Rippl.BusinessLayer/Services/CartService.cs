using Rippl.BusinessLayer.Helpers;
using Rippl.BusinessLayer.Interfaces.External;
using Rippl.BusinessLayer.Interfaces.Services;
using Rippl.DataLayer.Interfaces;
using Rippl.DataLayer.Models;

namespace Rippl.BusinessLayer.Services
{
    public class CartService : ICartService
    {
       
        private readonly IVoucherTransactionRepository _voucherTransactionRepository;
        private readonly IVoucherProviderService _voucherProviderService;
        public CartService(IVoucherProviderService voucherProviderService, IVoucherTransactionRepository voucherTransactionRepository)
        {
            _voucherProviderService = voucherProviderService;
            _voucherTransactionRepository = voucherTransactionRepository;
        }

        public async Task<HttpResponseMessage> AddToCart(Cart cart)
        {
            cart.TotalAmount = cart.CartItems.Sum(x =>  x.Amount * x.Quantity);

            if(cart.Id >  0)
            {
                return await _voucherProviderService.UpdateCart(cart);  
            }
            return await _voucherProviderService.CreateCart(cart);
        }

        public async Task<HttpResponseMessage> Checkout(Cart cart)
        {
            var response = await _voucherProviderService.Checkout(cart);

            var voucherTransaction = CartToTransactionMapper.MapCartToVoucherTransaction(cart);

            if (response.IsSuccessStatusCode) 
            {
                await _voucherTransactionRepository.CreateVoucherTransaction(voucherTransaction);
            }

            return response;
        }
    }
}
