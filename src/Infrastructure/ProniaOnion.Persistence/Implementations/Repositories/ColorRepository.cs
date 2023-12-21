using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Persistence.Contexts;
using ProniaOnion.Persistence.Implementations.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Persistence.Implementations.Repositories
{
    internal class ColorRepository:Repository<Color>,IColorRepository
    {
        public ColorRepository(AppDbContext db):base(db) { }
    }
}
