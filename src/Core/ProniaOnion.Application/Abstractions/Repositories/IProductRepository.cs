using ProniaOnion.Application.Abstractions.Repositories.Generic;
using ProniaOnion.Application.DTOs.Products;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Application.Abstractions.Repositories
{
    public interface IProductRepository:IRepository<Product>
    {
        
    }
}
