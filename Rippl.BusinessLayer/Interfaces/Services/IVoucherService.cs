using Rippl.DataLayer.Models;

namespace Rippl.BusinessLayer.Interfaces.Services
{
    public interface IVoucherService
    {
        Task<IEnumerable<Voucher>> ListVouchers();
        Task<Voucher> SelectVoucherAndAmount(int id);
    }
}
