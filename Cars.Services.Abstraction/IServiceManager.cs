using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Services.Abstraction
{
    public interface IServiceManager
    {
        IBrandService BrandService { get; }
        IModelService ModelService { get; }
    }
}
