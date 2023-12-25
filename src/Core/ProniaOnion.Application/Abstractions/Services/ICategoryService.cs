using ProniaOnion.Application.DTOs.Categories;

namespace ProniaOnion.Application.Abstractions.Services
{
    public interface ICategoryService
    {
        Task<ICollection<CategoryItemDto>> GetAllAsync(int page, int take);
        Task<CategoryGetDto> GetByIdAsync(int id);
        Task CreateAsync(CategoryCreateDto categoryDto);
        Task UpdateAsync(int id,CategoryUpdateDto categoryDto);
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
        Task ReverseSoftDelete(int id);
    }
}
