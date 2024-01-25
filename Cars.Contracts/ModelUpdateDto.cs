using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Contracts
{
    public class ModelUpdateDto
    {
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
