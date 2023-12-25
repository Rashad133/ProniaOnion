using Microsoft.AspNetCore.Mvc;
using ProniaOnion.Application.DTOs.Products;

namespace ProniaOnion.Application.Abstractions.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductItemDto>> GetAllPaginated(int page, int take);
        Task<ProductGetDto> GetByIdAsync(int id);
        Task CreateAsync(ProductCreateDto dto);
        Task UpdateAsync(int id,ProductUpdateDto dto);
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
        Task ReverseSoftDeleteAsync(int id);
    }
}
