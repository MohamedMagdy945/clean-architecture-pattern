
using App.Data.Entities;

namespace App.Data.Interfaces
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
