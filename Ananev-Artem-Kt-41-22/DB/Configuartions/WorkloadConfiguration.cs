using Ananev_Artem_Kt_41_22.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Ananev_Artem_Kt_41_22.DB.Configuartions
{
    public class WorkloadConfiguration : IEntityTypeConfiguration<Workload>
    {
        private const string TableName = "cd_workload";

        public void Configure(EntityTypeBuilder<Workload> builder)
        {
            builder.HasKey(p => p.WorkloadId)
                   .HasName($"pk_{TableName}_workload_id");

            builder.Property(p => p.WorkloadId)
                   .ValueGeneratedOnAdd();

            builder.Property(p => p.Hours)
                   .IsRequired()
                   .HasColumnName("c_workload_hours")
                   .HasColumnType("int")
                   .HasComment("Количество часов нагрузки по дисциплине");

            // Внешний ключ - дисциплина
            builder.HasOne(w => w.Discipline)
                   .WithMany(d => d.Workloads)
                   .HasForeignKey(w => w.DisciplineId)
                   .HasConstraintName($"fk_{TableName}_discipline_id");

            // Внешний ключ - преподаватель
            builder.HasOne(w => w.Teacher)
                   .WithMany(t => t.Workloads)
                   .HasForeignKey(w => w.TeacherId)
                   .HasConstraintName($"fk_{TableName}_teacher_id");
        }
    }
}