using Microsoft.EntityFrameworkCore;
using PaymentRegister_.net_core5_angular11.Models;

namespace WebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options
        ) :
            base(options)
        {
        }

        public DbSet<PaymentDetails> paymentDetails { get; set; }
    }
}
