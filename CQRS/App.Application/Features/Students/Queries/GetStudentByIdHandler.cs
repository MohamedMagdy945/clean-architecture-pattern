using App.Application.DTOs;
using App.Domain.Interfaces;

namespace App.Application.Features.Students.Queries
{
    public class GetStudentByIdHandler
    {
        private readonly IStudentRepository _studentRepository;

        public GetStudentByIdHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<StudentResponse?> HandleAsync(GetStudentByIdQuery query)
        {
            var student = await _studentRepository.GetByIdAsync(query.Id);

            if (student == null) return null;

            return new StudentResponse(student.Id, student.Name, student.Email, student.Phone, student.DateOfBirth, student.GPA, student.Address);
        }
    }
}
