using ProniaOnion.Application.DTOs.Tag;

namespace ProniaOnion.Application.Abstractions.Services;

public interface ITagService
{
    Task<ICollection<TagItemDto>> GetAllAsync(int page, int take);
    Task<TagGetDto> GetByIdAsync(int id);
    Task CreateAsync(TagCreateDto tagDto);
    Task UpdateAsync(TagUpdateDto tagDto);
    Task DeleteAsync(int id);
    Task SoftDeleteAsync(int id);
    Task ReverseSoftDeleteAsync(int id);

}
