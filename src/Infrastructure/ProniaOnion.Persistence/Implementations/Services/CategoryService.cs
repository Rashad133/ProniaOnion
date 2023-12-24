using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.Categories;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Persistence.Implementations.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICollection<CategoryItemDto>> GetAllAsync(int page, int take)
        {
            ICollection<Category> categories = await _repository.GetAllWhere(skip: (page - 1) * take, take: take, isTracking: false,ignoreQuery:true).ToListAsync();

            ICollection<CategoryItemDto> categoryDtos= _mapper.Map<ICollection<CategoryItemDto>>(categories);
            

            return categoryDtos;
        }
        public async Task CreateAsync(CategoryCreateDto categoryDto)
        {
            await _repository.AddAsync(_mapper.Map<Category>(categoryDto));
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(CategoryUpdateDto categoryDto)
        {
            Category category = await _repository.GetByIdAsync(categoryDto.id);
            if (category is null) throw new Exception("Not Found");

            category.Name = categoryDto.name;
            _mapper.Map(categoryDto, category);

            _repository.Update(category);
            await _repository.SaveChangesAsync();
        }

        public async Task SoftDeleteAsync(int id)
        {
            Category category = await _repository.GetByIdAsync(id);
            if (category is null) throw new Exception("Not Found");
            _repository.ReverseSoftDelete(category);
            await _repository.SaveChangesAsync();
        }



        //public async Task<GetCategoryDto> GetAsync(int id)
        //{
        //    Category category = await _repository.GetByIdAsync(id);
        //    if (category is null) throw new Exception("Not Found");

        //    return new GetCategoryDto
        //    {
        //        Id = category.Id,
        //        Name = category.Name,
        //    };
        //}

        //public async Task DeleteAsync(int id)
        //{
        //    Category category = await _repository.GetByIdAsync(id);

        //    if (category is null) throw new Exception("Not Found");

        //    _repository.Delete(category);
        //    await _repository.SaveChangesAsync();
        //}
    }
}
