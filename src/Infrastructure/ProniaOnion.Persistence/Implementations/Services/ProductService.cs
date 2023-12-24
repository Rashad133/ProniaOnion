using AutoMapper;
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
        private readonly IMapper _mapper;
        public ProductService(IProductRepository repository,IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task CreateAsync(ProductCreateDto productDto)
        {
            bool existed = await _repository.isExistAsync(p=>p.Name==productDto.Name);
            if (existed) throw new Exception("product is existed");
            await _repository.AddAsync(_mapper.Map<Product>(productDto));
            await _repository.SaveChangesAsync();
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
    }
}
