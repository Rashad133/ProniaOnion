using ProniaOnion.Application.DTOs.Tag;

namespace ProniaOnion.Application.Abstractions.Services;

public interface ITagService
{
    Task<ICollection<TagItemDto>> GetAllAsync(int page, int take);
    Task CreateAsync(TagCreateDto tagDto);
    Task UpdateAsync(TagUpdateDto tagDto);
    Task SoftDeleteAsync(int id);
}
