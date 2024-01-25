using Cars.Domain.Entities;
using Cars.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Persistence.Repositories
{
    internal sealed class ModelRepository : IModelRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public ModelRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;

        public async Task<IEnumerable<Model>> GetAllByBrandIdAsync(Guid brandId, CancellationToken cancellationToken = default) =>
            await _dbContext.Models.Where(x => x.BrandId == brandId).ToListAsync(cancellationToken);

        public async Task<Model> GetByIdAsync(Guid modelId, CancellationToken cancellationToken = default) =>
            await _dbContext.Models.FirstOrDefaultAsync(x => x.Id == modelId, cancellationToken);

        public void Insert(Model model) => _dbContext.Models.Add(model);

        public void Remove(Model model) => _dbContext.Models.Remove(model);
    }
}
