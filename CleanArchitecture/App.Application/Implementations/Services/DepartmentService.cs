using App.Application.Interfaces.Repositories;
using App.Application.Interfaces.Services;
using App.Domain.Entities;

namespace App.Application.Implementations.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Department?> GetByIdAsync(int id)
        {

            var existingDepartment = await _unitOfWork.Departments.GetByIdAsync(id);
            if (existingDepartment != null)
                return existingDepartment;

            throw new KeyNotFoundException($"Department with id {id} not found.");
        }
        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            return await _unitOfWork.Departments.GetAllAsync();
        }

        public async Task AddAsync(Department department)
        {

            if (department == null)
                throw new ArgumentNullException(nameof(department));

            await _unitOfWork.Departments.AddAsync(department);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(Department department)
        {
            if (department == null)
                throw new ArgumentNullException(nameof(department));
            var existingDepartment = await _unitOfWork.Departments.GetByIdAsync(department.Id);

            if (existingDepartment == null)
                throw new KeyNotFoundException($"Department with id {department.Id} not found.");

            existingDepartment.Code = department.Code;

            existingDepartment.Name = department.Name;

            existingDepartment.Description = department.Description;

            existingDepartment.IsActive = department.IsActive;

            _unitOfWork.Departments.Update(existingDepartment);
        }
        public async Task DeleteAsync(int id)
        {
            var existingDepartment = await _unitOfWork.Departments.GetByIdAsync(id);
            if (existingDepartment != null)
            {
                throw new KeyNotFoundException($"Department with id {id} not found.");
            }

            _unitOfWork.Departments.Delete(existingDepartment);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
