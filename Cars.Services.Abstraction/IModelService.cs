using Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Services.Abstraction
{
    public interface IModelService
    {   
        Task<IEnumerable<ModelDto>> GetAllByBrandIdAsync(Guid brandId, CancellationToken cancellationToken = default);
        Task<ModelDto> GetByIdAsync(Guid brandId, CancellationToken cancellationToken= default);
        Task<ModelDto> CreateAsync(Guid brandId, ModelCreationDto modelCreationDto, CancellationToken cancellationToken = default);
        Task UpdateAsync(Guid brandId, Guid modelId, ModelUpdateDto modelUpdateDto, CancellationToken cancellationToken = default);
        Task RemoveAsync(Guid brandId, Guid modelId, CancellationToken cancellationToken = default);  
    }
}
