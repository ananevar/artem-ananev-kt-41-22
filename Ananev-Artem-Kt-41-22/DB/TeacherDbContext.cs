using Ananev_Artem_Kt_41_22.DB.Configuartions;
using Ananev_Artem_Kt_41_22.Models;
using Microsoft.EntityFrameworkCore;

namespace Ananev_Artem_Kt_41_22.DB
{
    public class TeacherDbContext : DbContext
    {
        DbSet<Teacher> Teachers { get; set; }
        DbSet<Discipline> Disciplines { get; set; }
        DbSet<AcademicDegree> AcademicDegrees { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<Staff> Staffers { get; set; }
        DbSet<Workload> Workloads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new DisciplineConfiguration());
            modelBuilder.ApplyConfiguration(new AcademicDegreeConfiguration());
            modelBuilder.ApplyConfiguration(new DisciplineConfiguration());
            modelBuilder.ApplyConfiguration(new StaffConfiguration());
            modelBuilder.ApplyConfiguration(new WorkloadConfiguration());
        }

        public TeacherDbContext(DbContextOptions<TeacherDbContext> options) : base(options)
        {
        }
    }
}

