using Rippl.DataLayer.Models;

namespace Rippl.DataLayer.Interfaces
{
    public interface IVoucherTransactionRepository
    {
        Task<int> CreateVoucherTransaction(VoucherTransaction transaction);
    }
}
