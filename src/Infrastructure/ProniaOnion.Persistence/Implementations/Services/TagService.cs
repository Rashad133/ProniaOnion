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
        public async Task CreateAsync(TagCreateDto tagDto)
        {
            await _repository.AddAsync(_mapper.Map<Tag>(tagDto));
            await _repository.SaveChangesAsync();
        }

        public async Task SoftDeleteAsync(int id)
        {
            Tag tag = await _repository.GetByIdAsync(id);
            if (tag is null) throw new Exception("Not Found");
            _repository.SoftDelete(tag);
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

        //Task<ICollection<TagItemDto>> ITagService.GetAllAsync(int page, int take)
        //{
        //    ICollection<Tag> tags = await _repository.GetAllAsync(skip: (page - 1) * take, take: take, isTracking: false, isDeleted: true).ToListAsync();

        //    ICollection<CategoryItemDto> categoryDtos = _mapper.Map<ICollection<CategoryItemDto>>(tags);


        //    return categoryDtos;
        //}
    }
}
