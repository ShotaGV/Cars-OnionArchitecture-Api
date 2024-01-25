using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Domain.Exceptions
{

    public sealed class ModelDoesNotBelongToModelException : BadRequestException
    {
        public ModelDoesNotBelongToModelException(Guid brandId, Guid modelId)
        : base($"The account with the identifier {modelId} does not belog to owner {brandId}")
        {
        }
    }
}
