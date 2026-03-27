using App.Data.Entities;

namespace App.Business.Interfaces
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
