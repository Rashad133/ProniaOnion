using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.Categories;
using ProniaOnion.Application.DTOs.Tag;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Persistence.Implementations.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _repository;
        private readonly IMapper _mapper;
        public TagService(ITagRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task CreateAsync(TagCreateDto tagDto)
        {
            await _repository.AddAsync(_mapper.Map<Tag>(tagDto));
            await _repository.SaveChangesAsync();
        }

        public async Task<ICollection<TagItemDto>> GetAllAsync(int page, int take)
        {
            ICollection<Tag> tags = await _repository.GetAllWhere(skip: (page - 1) * take, take: take, isTracking: false, ignoreQuery: true).ToListAsync();

            ICollection<TagItemDto> tagDtos = _mapper.Map<ICollection<TagItemDto>>(tags);


            return tagDtos;
        }

        public async Task SoftDeleteAsync(int id)
        {
            Tag tag = await _repository.GetByIdAsync(id);
            if (tag is null) throw new Exception("Not Found");
            _repository.ReverseSoftDelete(tag);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(TagUpdateDto tagDto)
        {
            Tag tag = await _repository.GetByIdAsync(tagDto.Id);
            if (tag is null) throw new Exception("Not Found");

            tag.Name = tagDto.Name;
            _mapper.Map(tagDto, tag);

            _repository.Update(tag);
            await _repository.SaveChangesAsync();
        }

        
    }
}
