using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.DTOs.Products
{
    public record ProductCreateDto(string Name, decimal Price, string SKU, string? Description,int CategoryId,ICollection<int> ColorIds);
    
    
}
