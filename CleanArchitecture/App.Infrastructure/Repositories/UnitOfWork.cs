using App.Application.Interfaces.Repositories;
using App.Domain.Entities;
using App.Infrastructure.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace App.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IDbContextTransaction? _transaction;
        private IGenericRepository<Student>? _students;
        private IGenericRepository<Department>? _departments;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<Student> Students =>
       _students ??= new GenericRepository<Student>(_context);

        public IGenericRepository<Department> Departments =>
            _departments ??= new GenericRepository<Department>(_context);

        public bool HasActiveTransaction => _transaction != null;

        public async Task BeginTransactionAsync()
        {
            if (_transaction != null)
                return;

            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction == null)
                return;

            await _context.SaveChangesAsync();
            await _transaction.CommitAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction == null)
                return;

            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
