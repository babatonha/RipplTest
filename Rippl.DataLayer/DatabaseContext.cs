using Microsoft.EntityFrameworkCore;
using Rippl.DataLayer.Models;

namespace Rippl.DataLayer
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<VoucherTransaction> VoucherTransactions { get; set; }
        public DbSet<VoucherTransactionDetail> VoucherTransactionDetails { get; set; }
    }
}
