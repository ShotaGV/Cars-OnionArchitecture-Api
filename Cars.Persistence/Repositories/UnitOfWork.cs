using Cars.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Persistence.Repositories
{
    internal sealed class UnitOfWork : IUnitOfWork
    {
        private readonly RepositoryDbContext _dbContext;

        public UnitOfWork(RepositoryDbContext dbContext) => _dbContext = dbContext;

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            _dbContext.SaveChangesAsync(cancellationToken);
    }
}
