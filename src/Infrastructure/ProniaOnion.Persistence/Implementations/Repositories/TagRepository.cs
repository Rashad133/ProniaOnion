using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Domain.Entities;
using ProniaOnion.Persistence.Contexts;
using ProniaOnion.Persistence.Implementations.Repositories.Generic;

namespace ProniaOnion.Persistence.Implementations.Repositories
{
    public class TagRepository:Repository<Tag>,ITagRepository
    {
        public TagRepository(AppDbContext db):base(db) 
        {
            
        }
    }
}
