using ContractTracker.Repository.Context;

namespace ContractTracker.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        TrackerDbContext GetContext();
        Task BeginTransactionAsync();
        void Commit();
        void Rollback();
    }
}
