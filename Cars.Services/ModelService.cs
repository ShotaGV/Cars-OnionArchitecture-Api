using Cars.Contracts;
using Cars.Domain.Entities;
using Cars.Domain.Exceptions;
using Cars.Domain.Repositories;
using Cars.Services.Abstraction;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Services
{
    internal sealed class ModelService : IModelService
    {
        private readonly IRepositoryManager _repositoryManager;
        public ModelService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;

        public async Task<IEnumerable<ModelDto>> GetAllByBrandIdAsync(Guid brandId, CancellationToken cancellationToken = default)
        {
            var models = await _repositoryManager.ModelRepository.GetAllByBrandIdAsync(brandId, cancellationToken);
            var modelsDto = models.Adapt<IEnumerable<ModelDto>>();
            return modelsDto;
        }
        public async Task<ModelDto> GetByIdAsync(Guid modelId, CancellationToken cancellationToken = default)
        {
            var model = await _repositoryManager.ModelRepository.GetByIdAsync(modelId, cancellationToken);
            if (model == null)
            {
                throw new ModelNotFoundException(modelId);
            }
            var modelDto = model.Adapt<ModelDto>();
            return modelDto;
        }
        public async Task<ModelDto> CreateAsync(Guid brandId, ModelCreationDto modelCreationDto,CancellationToken cancellationToken = default)
        {
            var brand = await _repositoryManager.BrandRepository.GetByIdAsync(brandId, cancellationToken);
            if (brand == null)
            {
                throw new BrandNotFoundException(brandId);
            }
            var model = modelCreationDto.Adapt<Model>();
            model.BrandId = brand.Id;
            _repositoryManager.ModelRepository.Insert(model);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
            return model.Adapt<ModelDto>();
        }
        public async Task UpdateAsync(Guid brandId, Guid modelId, ModelUpdateDto modelUpdateDto, CancellationToken cancellationToken = default)
        {
            var brand = await _repositoryManager.BrandRepository.GetByIdAsync(brandId, cancellationToken);
            if (brand == null)
            {
                throw new BrandNotFoundException(brandId);
            }
            var model = await _repositoryManager.ModelRepository.GetByIdAsync(modelId, cancellationToken);
            if (model == null)
            {
                throw new ModelNotFoundException(brandId);
            }
            if (model.BrandId != brand.Id)
            {
                throw new ModelDoesNotBelongToModelException(brand.Id, model.Id);
            }
            model.Name = modelUpdateDto.Name;
            model.DateCreated = modelUpdateDto.DateCreated;
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
        public async Task RemoveAsync(Guid brandId, Guid modelId, CancellationToken cancellationToken = default)
        {
            var brand = await _repositoryManager.BrandRepository.GetByIdAsync(brandId, cancellationToken);
            if (brand == null)
            {
                throw new BrandNotFoundException(brandId);
            }
            var model = await _repositoryManager.ModelRepository.GetByIdAsync(modelId, cancellationToken);
            if (model == null)
            {
                throw new ModelNotFoundException(brandId);
            }
            if (model.BrandId != brand.Id)
            {
                throw new ModelDoesNotBelongToModelException(brand.Id, model.Id);
            }
            _repositoryManager.ModelRepository.Remove(model);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
