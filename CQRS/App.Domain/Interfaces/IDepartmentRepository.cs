using App.Domain.Entities;

namespace App.Domain.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAllDepartmentsAsync();
        Task<Department?> GetDepartmentWithStudentsAsync(int id);
    }
}