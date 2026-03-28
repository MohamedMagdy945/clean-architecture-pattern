using App.Domain.Entities;
using App.Domain.Interfaces;

namespace App.Application.Features.Students.Commands
{
    public class CreateStudentHandler
    {
        private readonly IStudentRepository _studentRepository;

        public CreateStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task HandleAsync(CreateStudentCommand command)
        {
            var student = new Student
            {
                Name = command.Name,
                DepartmentId = command.DepartmentId
            };

            await _studentRepository.AddAsync(student);
        }
    }
}
