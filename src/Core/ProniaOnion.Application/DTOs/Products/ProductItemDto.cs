using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.DTOs.Products
{
    public record ProductItemDto(int id,string Name,decimal Price,string SKU,string? Description);
    
    
}
