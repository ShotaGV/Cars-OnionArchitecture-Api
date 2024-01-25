using Cars.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Domain.Repositories
{
    public interface IBrandRepository
    {
        Task<IEnumerable<Brand>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Brand> GetByIdAsync(Guid brandId, CancellationToken cancellationToken = default);
        void Insert(Brand brand);
        void Remove(Brand brand);
    }
}
