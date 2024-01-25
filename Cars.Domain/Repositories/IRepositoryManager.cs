using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Domain.Repositories
{
    public interface IRepositoryManager
    {
        IBrandRepository BrandRepository { get; }
        IModelRepository ModelRepository { get; }
        IUnitOfWork UnitOfWork { get; }
    }
}
