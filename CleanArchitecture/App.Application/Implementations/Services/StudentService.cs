using App.Application.Interfaces.Repositories;
using App.Application.Interfaces.Services;
using App.Domain.Entities;

namespace App.Application.Implementations.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _unitOfWork.Students.GetByIdAsync(id);
        }
        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _unitOfWork.Students.GetAllAsync();
        }
        public async Task AddAsync(Student student)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student));

            if (student.DepartmentId <= 0)
                throw new ArgumentException("DepartmentId must be greater than zero.");

            var department = await _unitOfWork.Departments.GetByIdAsync(student.DepartmentId);

            if (department == null)
                throw new ArgumentException($"Department with Id {student.DepartmentId} does not exist.");

            await _unitOfWork.Students.AddAsync(student);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student student)
        {

            if (student == null)
                throw new ArgumentNullException(nameof(student));

            if (student.DepartmentId <= 0)
                throw new ArgumentException("DepartmentId must be greater than zero.");

            var department = await _unitOfWork.Departments.GetByIdAsync(student.DepartmentId);

            var existingStudent = await _unitOfWork.Students.GetByIdAsync(student.Id);

            if (existingStudent == null)
                throw new ArgumentException($"Student with Id {student.Id} does not exist.");

            _unitOfWork.Students.Update(student);

            await _unitOfWork.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var existingStudent = await _unitOfWork.Students.GetByIdAsync(id);

            if (existingStudent == null)
                throw new ArgumentException($"Student with Id {id} does not exist.");

            _unitOfWork.Students.Delete(existingStudent);

            await _unitOfWork.SaveChangesAsync();
        }

    }
}
