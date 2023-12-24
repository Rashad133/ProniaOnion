using ProniaOnion.Domain.Entities;
using System.Linq.Expressions;

namespace ProniaOnion.Application.Abstractions.Repositories.Generic
{
    public interface IRepository<T> where T : BaseEntity, new()
    {
        IQueryable<T> GetAll(
            bool isTracking = false,
            bool ignoreQuery = false,
            params string[] includes
            );
        IQueryable<T> GetAllWhere(
            Expression<Func<T, bool>>? expression = null,
            Expression<Func<T, object>>? orderExpression = null,
            bool isDescending = false,
            int skip = 0,
            int take = 0,
            bool isTracking = false,
            bool ignoreQuery = false,
            params string[] includes
            );
        Task<T> GetByIdAsync(int id,bool isTracking=true,bool ignoreQuery=false,params string[] includes);
        Task<T> GetByExpressionAsync(Expression<Func<T,bool>> expression, bool isTracking = true, bool ignoreQuery = false, params string[] includes);
        Task<bool> isExistAsync(Expression<Func<T, bool>> expression, bool ignoreQuery = false);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        void ReverseSoftDelete(T entity);
        Task SaveChangesAsync();
    }
}
