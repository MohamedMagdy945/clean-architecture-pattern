namespace App.Data.Entities
{
    public class Student : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; } = string.Empty;
        public double GPA { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; } = default!;
    }
}
