using Cars.Domain.Entities;
using Cars.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Persistence.Repositories
{
    internal sealed class BrandRepository : IBrandRepository
    {
        private readonly RepositoryDbContext _dbContext;
        public BrandRepository(RepositoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Brand>> GetAllAsync(CancellationToken cancellationToken = default) =>
            await _dbContext.Brands.Include(x => x.Models).ToListAsync(cancellationToken);
        public async Task<Brand> GetByIdAsync(Guid brandId, CancellationToken cancellationToken = default) =>
           await _dbContext.Brands.Include(x => x.Models).FirstOrDefaultAsync(x => x.Id == brandId, cancellationToken);

        public void Insert(Brand brand) => _dbContext.Brands.Add(brand);

        public void Remove(Brand brand) => _dbContext.Brands.Remove(brand);

    }
}
