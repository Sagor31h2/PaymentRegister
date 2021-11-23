using System.Threading.Tasks;

namespace WebApi.Repositories.IRepositories
{
    public interface IUnitOfWork
    {
        IPaymentRepository paymentRepository { get; }

        Task<bool> SaveAsync();
    }
}
