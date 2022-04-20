using ContractTracker.Repository.Context;
using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ContractTracker.Repository.Interfaces;

namespace ContractTracker.Repository.Implementation
{
     
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        
            private readonly TrackerDbContext _dbContext;

            public UnitOfWork(DbContextOptionsBuilder<TrackerDbContext> optionsBuilder)
            {
                _dbContext = new TrackerDbContext(optionsBuilder.Options);
            }

            //hm? There has got to be a better way of setting which db to use for unit testing rather than passing it around like a hot potato
            public TrackerDbContext GetContext() { return _dbContext; }

            public async Task BeginTransactionAsync()
            {

                /* For Isolation Levels:
                 * So if you have using Microsoft.EntityFrameworkCore; and don't see it, add reference to the Microsoft.EntityFrameworkCore.Relational.dll assembly / package.*/
                await _dbContext.Database.BeginTransactionAsync();
            }
            public void Commit()
            {
                _dbContext.Database.CommitTransaction();
            }

            public void Rollback()
            {
                _dbContext.Database.RollbackTransaction();
            }
            /*
            public async Task<int> SaveAsync()
            {
                return await _dbContext.SaveChangesAsync();
            } */

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
