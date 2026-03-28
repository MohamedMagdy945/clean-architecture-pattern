namespace App.Application.DTOs
{
    public record StudentResponse(int Id, string Name, string Email, string Phone, DateTime DateOfBirth, double GPA, string Address);

    public record CreateStudentDto(string Name, string Email, string Phone, DateTime DateOfBirth, int DepartmentId);

    public record UpdateStudentDto(int Id, string Name, string Email, string Phone, DateTime DateOfBirth, int DepartmentId);
}
