using Ananev_Artem_Kt_41_22.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ananev_Artem_Kt_41_22.DB.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        private const string TableName = "cd_department";

        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(p => p.DepartmentId)
                   .HasName($"pk_{TableName}_department_id");

            builder.Property(p => p.DepartmentId)
                   .ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasColumnName("c_department_name")
                   .HasColumnType("nvarchar")
                   .HasMaxLength(200);

            builder.HasOne(d => d.HeadTeacher)
                   .WithOne()
                   .HasForeignKey<Department>(d => d.HeadTeacherId)
                   .HasConstraintName($"fk_{TableName}_head_teacher_id")
                   .OnDelete(DeleteBehavior.NoAction);

        }
    }
}