using ContractTracker.Repository.Interfaces;
using ContractTracker.Repository.Context;
using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace ContractTracker.Repository.Implementation
{
    //TOOD in memory DBs do not handle transactions
    public class MockUnitOfWork : IUnitOfWork,  IDisposable
    {
        private readonly TrackerDbContext _dbContext; //TODO in memory DB, no the actual db context

        public MockUnitOfWork(DbContextOptionsBuilder<TrackerDbContext> optionsBuilder)
        {
            _dbContext = new TrackerDbContext(optionsBuilder.Options);
        }

        //hm? There has got to be a better way of setting which db to use for unit testing rather than passing it around like a hot potato
        public TrackerDbContext GetContext() { return _dbContext; }

        /// <summary>
        /// In memory DB's do not process transactions.
        /// </summary>
        /// <returns></returns>
        public async Task BeginTransactionAsync()
        {
            await Task.Run( () => { return null; });
        }
        public void Commit()
        {
            return;
        }

        public void Rollback()
        {
            return;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #region protected methods
        private bool _disposed = false;

        /// <summary>
        /// In case this is used in a Using statement.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this._disposed = true;
        }
        #endregion
    }
}
