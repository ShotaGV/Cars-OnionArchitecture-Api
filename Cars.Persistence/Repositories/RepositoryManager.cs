using Cars.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Persistence.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IBrandRepository> _lazyBrandRepository;
        private readonly Lazy<IModelRepository> _lazyModelRepository;
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

        public RepositoryManager(RepositoryDbContext dbContext)
        {
            _lazyBrandRepository = new Lazy<IBrandRepository>(() => new BrandRepository(dbContext)); 
            _lazyModelRepository = new Lazy<IModelRepository>(() => new ModelRepository(dbContext));
            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));
        }
        public IBrandRepository BrandRepository => _lazyBrandRepository.Value;

        public IModelRepository ModelRepository => _lazyModelRepository.Value;

        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
    }
}
