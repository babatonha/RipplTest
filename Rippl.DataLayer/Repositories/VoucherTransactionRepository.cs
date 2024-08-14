using Rippl.DataLayer;
using Rippl.DataLayer.Interfaces;
using Rippl.DataLayer.Models;

namespace Rippl.BusinessLayer.Services
{
    public class VoucherTransactionRepository : IVoucherTransactionRepository
    {
        private readonly DatabaseContext _context;
        public VoucherTransactionRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<int> CreateVoucherTransaction(VoucherTransaction transaction)
        {
            await _context.VoucherTransactions.AddAsync(transaction);

            var transactionId = await _context.SaveChangesAsync();

            if (transactionId > 0)
            {
                foreach (var item in transaction.TransactionDetails)
                {
                    item.VoucherTransactionId = transactionId;
                    await _context.AddAsync(item);
                }

                await _context.SaveChangesAsync();
            }

            return transactionId;
        }
    }
}
