using Cars.Domain.Repositories;
using Cars.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IBrandService> _lazyBrandService;
        private readonly Lazy<IModelService> _lazyModelService;
        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _lazyBrandService = new Lazy<IBrandService>(() => new BrandService(repositoryManager));
            _lazyModelService = new Lazy<IModelService>(() => new ModelService(repositoryManager));
        }
        public IBrandService BrandService => _lazyBrandService.Value;
        public IModelService ModelService => _lazyModelService.Value;
    }
}
