using App.Application.Interfaces;
using App.Application.Interfaces.Repositories;
using App.Domain.Entities;
using App.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace App.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<IReadOnlyList<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }
        public async Task<T> GetEntityWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }
        public async Task<IReadOnlyList<T>> ListWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _dbSet.AnyAsync(e => e.Id == id);
        }
        public void SoftDelete(T entity)
        {
            entity.IsDeleted = true;
            entity.UpdatedAt = DateTime.Now;
            Update(entity);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbSet.AsQueryable(), spec);
        }
        internal class SpecificationEvaluator<T> where T : BaseEntity
        {
            public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> spec)
            {
                var query = inputQuery;

                if (spec.Criteria != null)
                {
                    query = query.Where(spec.Criteria);
                }

                query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

                query = spec.IncludeStrings.Aggregate(query, (current, include) => current.Include(include));

                if (spec.OrderBy != null)
                {
                    query = query.OrderBy(spec.OrderBy);
                }

                if (spec.OrderByDescending != null)
                {
                    query = query.OrderByDescending(spec.OrderByDescending);
                }

                if (spec.IsPagingEnabled)
                {
                    query = query.Skip(spec.Skip).Take(spec.Take);
                }

                return query;
            }
        }
    }
}
