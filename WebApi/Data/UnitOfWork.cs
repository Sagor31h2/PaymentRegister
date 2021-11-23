using System.Threading.Tasks;
using WebApi.Repositories;
using WebApi.Repositories.IRepositories;

namespace WebApi.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IPaymentRepository paymentRepository =>
            new PaymentRepository(_dbContext);

        public async Task<bool> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
