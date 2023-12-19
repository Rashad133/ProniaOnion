using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Domain.Entities
{
    public class BaseNameableEntity:BaseEntity
    {
        public string Name { get; set; } = null!;
    }
}
