namespace App.Application.DTOs
{
    public record DepartmentDto(int Id, string Name, string Code, string Description, int StudentCount, DateTime CreatedAt);
    public record CreateDepartmentDto(string Name, string Code, string Description);
    public record UpdateDepartment(int Id, string Name, string Code, string Description);
}
