using System.Collections.Generic;
using System.Threading.Tasks;
using PaymentRegister_.net_core5_angular11.Models;

namespace WebApi.Repositories.IRepositories
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<PaymentDetails>> AllpaymentDetails();

        Task<PaymentDetails> GetPaymentDetails(int id);

        Task<bool> PutPaymentDetails(PaymentDetails paymentDetails);

        Task<bool> PostPaymentDetails(PaymentDetails paymentDetails);

        void DeletePaymentDetails(int id);

        bool PaymentDetailsExists(int id);
    }
}
