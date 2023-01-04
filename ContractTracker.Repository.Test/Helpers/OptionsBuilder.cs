using ContractTracker.Repository.Context;
using ContractTracker.Repository.Implementation;
using ContractTracker.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace ContractTracker.Repository.Test.Helpers
{
    internal class OptionsBuilder
    {
        public DbContextOptionsBuilder<TrackerDbContext> BuildContext()
        {
            var builder = new DbContextOptionsBuilder<TrackerDbContext>()
                                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            return builder;
        }

        public IUnitOfWork BuildMockUnitOfWork()
        {
            var builder = BuildContext();
            var uow = new MockUnitOfWork(builder);
            return uow;
        }
    }
}
