using Cars.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Domain.Repositories
{
    public interface IModelRepository
    {
        Task<IEnumerable<Model>> GetAllByBrandIdAsync(Guid brandId, CancellationToken cancellationToken = default);
        Task<Model> GetByIdAsync(Guid modelId, CancellationToken cancellationToken = default);
        void Insert(Model model);   
        void Remove(Model model);
    }
}
