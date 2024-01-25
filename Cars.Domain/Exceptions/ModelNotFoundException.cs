using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Domain.Exceptions
{
    public sealed class ModelNotFoundException : NotFoundException
    {
        public ModelNotFoundException(Guid modelId)
            : base($"Brand: {modelId} was not found")
        {
        }
    }
}
