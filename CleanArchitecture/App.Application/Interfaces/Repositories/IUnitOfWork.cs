using App.Domain.Entities;

namespace App.Application.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IGenericRepository<Student> Students { get; }
        IGenericRepository<Department> Departments { get; }
        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
        bool HasActiveTransaction { get; }
    }
}
