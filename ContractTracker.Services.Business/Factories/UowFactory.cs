using ContractTracker.Repository.Context;
using ContractTracker.Repository.Implementation;
using ContractTracker.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContractTracker.Services.Business.Factories
{
    public class UowFactory
    {
        private readonly string _connectionString;
        public UowFactory(string conString)
        {
            _connectionString = conString;
        }
        public IUnitOfWork BuildUnitOfWork()
        {
            var options = new DbContextOptionsBuilder<TrackerDbContext>().UseSqlServer(_connectionString);
            var uow = new UnitOfWork(options);
            return uow;
        }
    }
}
