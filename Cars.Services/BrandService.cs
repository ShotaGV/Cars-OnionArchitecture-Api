using Cars.Contracts;
using Cars.Domain.Entities;
using Cars.Domain.Exceptions;
using Cars.Domain.Repositories;
using Cars.Services.Abstraction;
using Mapster;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Services
{
    internal sealed class BrandService : IBrandService
    {
        private readonly IRepositoryManager _repositoryManager;
        public BrandService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;
        public async Task<IEnumerable<BrandDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var brands = await _repositoryManager.BrandRepository.GetAllAsync(cancellationToken);
            var brandDto = brands.Adapt<IEnumerable<BrandDto>>();
            return brandDto;
        }
        public async Task<BrandDto> GetByIdAsync(Guid brandId, CancellationToken cancellationToken = default)
        {
            var brand = await _repositoryManager.BrandRepository.GetByIdAsync(brandId, cancellationToken);
            if (brand == null)
            {
                throw new BrandNotFoundException(brandId);
            }
            var brandDto = brand.Adapt<BrandDto>();
            return brandDto;
        }
        public async Task<BrandDto> CreateAsync(BrandCreationDto brandCreationDto, CancellationToken cancellationToken = default)
        {
            var brand = brandCreationDto.Adapt<Brand>();
            _repositoryManager.BrandRepository.Insert(brand);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
            return brand.Adapt<BrandDto>();
        }
        public async Task UpdateAsync(Guid brandId, BrandUpdateDto brandUpdateDto, CancellationToken cancellationToken = default)
        {
            var brand = await _repositoryManager.BrandRepository.GetByIdAsync(brandId, cancellationToken);
            if(brand == null)
            {
                throw new BrandNotFoundException(brandId);
            }
            brand.Name = brandUpdateDto.Name;
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
        public async Task RemoveAsync(Guid brandId, CancellationToken cancellationToken = default)
        {
            var brand = await _repositoryManager.BrandRepository.GetByIdAsync(brandId, cancellationToken);
            if(brand == null)
            {
                throw new BrandNotFoundException(brandId);
            }
            _repositoryManager.BrandRepository.Remove(brand);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
