using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Domain.Entities
{
    public class Color:BaseNameableEntity
    {
        //Relational Properties
        public ICollection<ProductColor>? ProductColors { get; set;}
    }
}
