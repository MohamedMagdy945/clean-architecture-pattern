using App.Domain.Entities;

namespace App.Application.Interfaces.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetAllAsync();
        Task<Department?> GetByIdAsync(int id);
        Task AddAsync(Department student);
        Task UpdateAsync(Department student);
        Task DeleteAsync(int id);
    }
}
