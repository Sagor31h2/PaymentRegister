using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentRegister_.net_core5_angular11.Models
{
    public class PaymentDetailsContext : DbContext
    {
        public PaymentDetailsContext(DbContextOptions<PaymentDetailsContext> options) : base(options)
        {


        }
        public DbSet<PaymentDetails> paymentDetails { get; set; }
    }
}
