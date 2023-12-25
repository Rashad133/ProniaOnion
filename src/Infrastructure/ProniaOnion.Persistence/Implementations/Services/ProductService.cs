using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.Products;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Persistence.Implementations.Services
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _repository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IColorRepository _colorRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;
        public ProductService(
            IProductRepository repository
            ,ICategoryRepository categoryRepository
            ,IColorRepository colorRepository
            ,ITagRepository tagRepository
            ,IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
            _categoryRepository = categoryRepository;
            _colorRepository = colorRepository;
            _tagRepository= tagRepository;
        }
        public async Task<IEnumerable<ProductItemDto>> GetAllPaginated(int page, int take)
        {
            IEnumerable<ProductItemDto> dtos = _mapper.Map<IEnumerable<ProductItemDto>>(await _repository.GetAllWhere(skip:(page-1)*take,take:take,isTracking:false).ToArrayAsync());
            return dtos;
        }

        public async Task<ProductGetDto> GetByIdAsync(int id)
        {
            Product product = await _repository.GetByIdAsync(id,includes:nameof(Product.Category));
            ProductGetDto dto=_mapper.Map<ProductGetDto>(product);
            return dto;
        }

        public async Task CreateAsync(ProductCreateDto dto)
        {
            if (await _repository.isExistAsync(p => p.Name == dto.Name)) throw new Exception("Product is exists");
            if(!await _categoryRepository.isExistAsync(c => c.Id == dto.CategoryId)) throw new Exception("Don't Category exists");

            Product product=_mapper.Map<Product>(dto);
            product.ProductColors=new List<ProductColor>();
            foreach (var colorId in dto.ColorIds)
            {
                if (!await _colorRepository.isExistAsync(c => c.Id == colorId)) throw new Exception("Dont Color exists");

                product.ProductColors.Add(new ProductColor
                {
                    ColorId=colorId,

                });
            }
            await _repository.AddAsync(product);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id,[FromForm]ProductUpdateDto dto)
        {
            Product existed = await _repository.GetByIdAsync(id,includes:nameof(Product.ProductColors));
            if (existed is null) throw new Exception("not available");

            if (dto.CategoryId != existed.CategoryId)
            {
                if (!await _categoryRepository.isExistAsync(c=>c.Id==dto.CategoryId)) throw new Exception("dont existed");
            }
            existed =_mapper.Map(dto,existed);
            existed.ProductColors = existed.ProductColors.Where(pc => dto.ColorIds.Any(colId => pc.ColorId == colId)).ToList();

            foreach (var cId in dto.ColorIds)
            {
                if (!await _colorRepository.isExistAsync(c => c.Id == cId)) throw new Exception("Dont Color exists");
                if (!existed.ProductColors.Any(pc => pc.ColorId == cId))
                {
                    existed.ProductColors.Add(new ProductColor { ColorId = cId });
                }
            }
            _repository.Update(existed);
            await _repository.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            Product product= await _repository.GetByIdAsync(id);

            if (product is null) throw new Exception("Not Found");

            _repository.Delete(product);
            await _repository.SaveChangesAsync();
        }
        public async Task SoftDeleteAsync(int id)
        {
            Product product = await _repository.GetByIdAsync(id);

            if (product is null) throw new Exception("Not Found");

            _repository.SoftDelete(product);
            await _repository.SaveChangesAsync();
        }
        public async Task ReverseSoftDeleteAsync(int id)
        {
            Product product = await _repository.GetByIdAsync(id);

            if (product is null) throw new Exception("Not Found");

            _repository.SoftDelete(product);
            await _repository.SaveChangesAsync();
        }
    }
}
//public async Task CreateAsync(ProductCreateDto productDto)
//{
//    bool existed = await _repository.isExistAsync(p => p.Name == productDto.Name);
//    if (existed) throw new Exception("product is existed");
//    await _repository.AddAsync(_mapper.Map<Product>(productDto));
//    await _repository.SaveChangesAsync();
//}