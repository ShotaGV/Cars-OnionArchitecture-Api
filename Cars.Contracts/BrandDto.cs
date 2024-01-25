using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cars.Contracts
{
    public class BrandDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ModelDto> Models { get; set; }

    }
}
