using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.Categories;
using ProniaOnion.Application.DTOs.Colors;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Persistence.Implementations.Services
{
    public class ColorService : IColorService
    {
        private readonly IColorRepository _repository;
        private readonly IMapper _mapper;   
        public ColorService(IColorRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task CreateAsync(ColorCreateDto colorDto)
        {
            await _repository.AddAsync(_mapper.Map<Color>(colorDto));
            await _repository.SaveChangesAsync();
        }

        public async Task<ICollection<ColorItemDto>> GetAllAsync(int page, int take)
        {
            ICollection<Color> colors = await _repository.GetAllAsync(skip: (page - 1) * take, take: take, isTracking: false).ToListAsync();

            ICollection<ColorItemDto> colorDtos = _mapper.Map<ICollection<ColorItemDto>>(colors);


            return colorDtos;
        }

        public async Task SoftDeleteAsync(int id)
        {
            Color color = await _repository.GetByIdAsync(id);
            if (color is null) throw new Exception("Not Found");
            _repository.SoftDelete(color);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(ColorUpdateDto colorDto)
        {
            Color color = await _repository.GetByIdAsync(colorDto.Id);
            if (color is null) throw new Exception("Not Found");

            color.Name = colorDto.Name;
            _mapper.Map(colorDto, color);

            _repository.Update(color);
            await _repository.SaveChangesAsync();
        }
    }
}
