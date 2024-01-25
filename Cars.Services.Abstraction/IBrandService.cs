using Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Services.Abstraction
{
    public interface IBrandService
    {
        Task<IEnumerable<BrandDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<BrandDto> GetByIdAsync(Guid brandId, CancellationToken cancellationToken = default);
        Task<BrandDto> CreateAsync(BrandCreationDto brandCreationDto, CancellationToken cancellationToken = default);  
        Task UpdateAsync(Guid brandId, BrandUpdateDto brandUpdate, CancellationToken cancellationToken = default);
        Task RemoveAsync(Guid brandId, CancellationToken cancellationToken= default);
    }
}
