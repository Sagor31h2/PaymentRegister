using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PaymentRegister_.net_core5_angular11.Models;
using WebApi.Data;
using WebApi.Repositories.IRepositories;

namespace WebApi.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext _context;

        public PaymentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void DeletePaymentDetails(int id)
        {
            var PaymentId = _context.paymentDetails.Find(id);

            _context.paymentDetails.Remove (PaymentId);
        }

        public async Task<IEnumerable<PaymentDetails>> AllpaymentDetails()
        {
            return await _context.paymentDetails.ToListAsync();
        }

        public async Task<PaymentDetails> GetPaymentDetails(int id)
        {
            return await _context.paymentDetails.FindAsync(id);
        }

        public async Task<bool> PutPaymentDetails(PaymentDetails paymentDetails)
        {
            await _context.paymentDetails.AddAsync(paymentDetails);
            return true;
        }

        public async Task<bool>
        PostPaymentDetails(PaymentDetails paymentDetails)
        {
            await _context.paymentDetails.AddAsync(paymentDetails);
            return true;
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool PaymentDetailsExists(int id)
        {
            return _context.paymentDetails.Any(e => e.PaymentDetailsId == id);
        }
    }
}
