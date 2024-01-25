using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Domain.Exceptions
{
    public sealed class BrandNotFoundException : NotFoundException
    {
        public BrandNotFoundException(Guid brandId)
            : base($"Brand: {brandId} was not found")
        {
        }
    }
}
