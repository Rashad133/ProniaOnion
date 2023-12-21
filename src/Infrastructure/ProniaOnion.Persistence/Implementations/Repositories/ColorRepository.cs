using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.Abstractions.Repositories.Generic;
using ProniaOnion.Domain.Entities;
using ProniaOnion.Persistence.Contexts;
using ProniaOnion.Persistence.Implementations.Repositories.Generic;
using System.Collections.Generic;


namespace ProniaOnion.Persistence.Implementations.Repositories
{
    public  class ColorRepository:Repository<Color>,IColorRepository
    {
        public ColorRepository(AppDbContext db):base(db)
        {
            
        }
    }
}
