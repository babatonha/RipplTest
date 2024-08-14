using Microsoft.Extensions.Caching.Memory;
using Rippl.BusinessLayer.Interfaces.External;
using Rippl.BusinessLayer.Interfaces.Services;
using Rippl.DataLayer.Models;
using System.Net.Http.Json;

namespace Rippl.BusinessLayer.Services
{
    public class VoucherService : IVoucherService
    {
        private readonly IVoucherProviderService _voucherProviderService;
        private readonly IMemoryCache _memoryCache;
        private const string _voucherCacheKey = "Vouchers";
        public VoucherService(IVoucherProviderService voucherProviderService, IMemoryCache memoryCache)
        {
            _voucherProviderService = voucherProviderService;
            _memoryCache = memoryCache;
        }

        public async Task<IEnumerable<Voucher>> ListVouchers()
        {
            try
            {
                if (_memoryCache.TryGetValue(_voucherCacheKey, out IEnumerable<Voucher> vouchers))
                {
                    return vouchers;
                }

                var response = await _voucherProviderService.ListVouchers();

                if (response.IsSuccessStatusCode && response.Content != null)
                {
                    var vouchersFromExternalApi = await response.Content.ReadFromJsonAsync<IEnumerable<Voucher>>();

                    _memoryCache.Set(_voucherCacheKey, vouchersFromExternalApi, new MemoryCacheEntryOptions //we can use other caching services like redis
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
                    });

                    return vouchersFromExternalApi; // we can choose to paginate our response if we have a lot of data eg. vouchers.Skip(0).Take(10)
                }

                return new List<Voucher>();
            }
            catch (Exception ex)
            {
                //we can log the error
                return new List<Voucher>();
            }          
        }

        public async Task<Voucher> SelectVoucherAndAmount(int id)
        {
            try
            {
                var response = await _voucherProviderService.DetailVoucher(id);
                if (response.IsSuccessStatusCode && response.Content != null)
                {
                    return await response.Content.ReadFromJsonAsync<Voucher>();
                }
                //log response for failure
                return null;
            }
            catch (Exception ex)
            {

                //we can log the error
                return null;
            }

        }
    }
}
