using Microsoft.Extensions.Configuration;
using Rippl.BusinessLayer.Interfaces.External;
using Rippl.DataLayer.Models;
using System.Net.Http.Json;

namespace Rippl.BusinessLayer.Services.External
{
    public class VoucherProviderService : IVoucherProviderService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public VoucherProviderService(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _baseUrl = configuration.GetSection("VoucherProviderBaseUrl").Value ?? "http://fallback";
        }

        //TODO: we can perform health checks to see if the external api is working before we make a call.
        public async Task<HttpResponseMessage> CreateCart(Cart cart)
        {
            return await _httpClient.PostAsJsonAsync($"{_baseUrl}/api/vouchers/update", cart);
        }

        public async Task<HttpResponseMessage> DetailVoucher(int id)
        {
            return await _httpClient.GetAsync($"{_baseUrl}/api/vouchers/{id}");
        }

        public async Task<HttpResponseMessage> ListVouchers()
        {
            return await _httpClient.GetAsync($"{_baseUrl}/api/vouchers");
        }

        public async Task<HttpResponseMessage> Checkout(Cart cart)
        {
            return await _httpClient.GetAsync($"{_baseUrl}/api/vouchers/checkout");
        }

        public async Task<HttpResponseMessage> UpdateCart(Cart cart)
        {
            return  await _httpClient.PostAsJsonAsync($"{_baseUrl}/api/vouchers/update", cart);
        }
    }
}
