using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Configurations
{
    internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(d => d.Name)
               .IsRequired()
               .HasMaxLength(100);

            builder.Property(d => d.Code)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(d => d.Description)
                .HasMaxLength(500);

            builder.HasIndex(d => d.Code)
                .IsUnique();
        }
    }
}
