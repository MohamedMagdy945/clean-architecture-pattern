using App.Domain.Entities;
using System.Linq.Expressions;

namespace App.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T?> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SoftDelete(T entity);
        Task<bool> ExistsAsync(int id);
        Task<T> GetEntityWithSpecAsync(ISpecification<T> spec);
        Task<IReadOnlyList<T>> ListWithSpecAsync(ISpecification<T> spec);
    }
}
