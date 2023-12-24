
using ProniaOnion.Application.DTOs.Categories;

namespace ProniaOnion.Application.DTOs.Products
{
    public record ProductGetDto(int id,string Name,decimal Price,string SKU,string? Description,int CategoryId,IncludeCategoryDto Category);
    
}
