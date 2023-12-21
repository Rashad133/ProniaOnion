using ProniaOnion.Application.DTOs.Colors;

namespace ProniaOnion.Application.Abstractions.Services
{
    public interface IColorService
    {
        Task<ICollection<ColorItemDto>> GetAllAsync(int page, int take);
        //Task<GetCategoryDto> GetAsync(int id);
        Task CreateAsync(ColorCreateDto colorDto);
        Task UpdateAsync(ColorUpdateDto colorDto);
    }
}
