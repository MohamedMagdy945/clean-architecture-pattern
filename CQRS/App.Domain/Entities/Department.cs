namespace App.Domain.Entities
{
    public class Department : BaseEntity
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    }
}
