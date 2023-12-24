using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.DTOs.Products;
using ProniaOnion.Domain.Entities;
using ProniaOnion.Persistence.Contexts;
using ProniaOnion.Persistence.Implementations.Repositories.Generic;

namespace ProniaOnion.Persistence.Implementations.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext db):base(db) { }

        public Task<IEnumerable<ProductItemDto>> GetAllPaginated(int page, int take)
        {
            throw new NotImplementedException();
        }
    }
}
