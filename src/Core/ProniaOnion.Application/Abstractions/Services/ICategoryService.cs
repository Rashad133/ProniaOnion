using ProniaOnion.Application.DTOs.Categories;

namespace ProniaOnion.Application.Abstractions.Services
{
    public interface ICategoryService
    {
        Task<ICollection<CategoryItemDto>> GetAllAsync(int page, int take);
        Task CreateAsync(CategoryCreateDto categoryDto);
        Task UpdateAsync(CategoryUpdateDto categoryDto);
        Task SoftDeleteAsync(int id);
    }
}
