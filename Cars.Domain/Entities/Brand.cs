using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Domain.Entities
{
    public class Brand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Model> Models { get; set; }

    }
}
