using Ananev_Artem_Kt_41_22.DB;
using Ananev_Artem_Kt_41_22.Filters.DisciplineFilters;
using Ananev_Artem_Kt_41_22.Interfaces.DisciplineInterfaces;
using Ananev_Artem_Kt_41_22.Models;
using Microsoft.EntityFrameworkCore;

namespace Ananev_Artem_Kt_41_22.xUnitTests
{
    public class DisciplineServiceTests
    {
        private readonly DbContextOptions<TeacherDbContext> _dbContextOptions;

        public DisciplineServiceTests()
        {
            var dbName = $"TestDatabase_Discipline_{Guid.NewGuid()}";
            _dbContextOptions = new DbContextOptionsBuilder<TeacherDbContext>()
                .UseInMemoryDatabase(dbName)
                .Options;

            using var context = new TeacherDbContext(_dbContextOptions);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        [Fact]
        public async Task GetDisciplinesByHeadIdAsync_ReturnsDisciplinesForGivenHeadId()
        {
            int actualHeadId;

            // Arrange
            using (var context = new TeacherDbContext(_dbContextOptions))
            {
                var department = new Department { Name = "������� �����������", HeadId = 101 };
                await context.Departments.AddAsync(department);

                var teacher = new Teacher
                {
                    FirstName = "����",
                    LastName = "������",
                    DepartmentId = department.Id
                };
                await context.Teachers.AddAsync(teacher);
                await context.SaveChangesAsync();

                actualHeadId = department.HeadId ?? 0; 

                var discipline1 = new Discipline { Name = "����������������" };
                var discipline2 = new Discipline { Name = "���� ������" };
                await context.Disciplines.AddRangeAsync(discipline1, discipline2);
                await context.SaveChangesAsync();

                var load1 = new Load
                {
                    Hours = 30,
                    TeacherId = teacher.Id,
                    DisciplineId = discipline1.Id
                };
                var load2 = new Load
                {
                    Hours = 20,
                    TeacherId = teacher.Id,
                    DisciplineId = discipline2.Id
                };
                await context.Loads.AddRangeAsync(load1, load2);
                await context.SaveChangesAsync();
            }

            // Act + Assert
            using (var context = new TeacherDbContext(_dbContextOptions))
            {
                var disciplineService = new DisciplineService(context);
                var filter = new HeadIdDisciplineFilter { HeadIdName = actualHeadId };

                var result = await disciplineService.GetDisciplinesByHeadIdAsync(filter);

                Assert.Equal(2, result.Length);
                //Assert.Contains(result, d => d.Name == "����������������");
                //Assert.Contains(result, d => d.Name == "���� ������");
            }
        }

        [Fact]
        public async Task AddDisciplineAsync_AddsDisciplineSuccessfully()
        {
            using (var context = new TeacherDbContext(_dbContextOptions))
            {
                var disciplineService = new DisciplineService(context);
                var discipline = new Discipline { Name = "����������" };

                await disciplineService.AddDisciplineAsync(discipline);

                var addedDiscipline = await context.Disciplines.FindAsync(discipline.Id);
                Assert.NotNull(addedDiscipline);
                Assert.Equal("����������", addedDiscipline.Name);
            }
        }

        [Fact]
        public async Task UpdateDisciplineAsync_UpdatesDisciplineSuccessfully()
        {
            using (var context = new TeacherDbContext(_dbContextOptions))
            {
                var discipline = new Discipline { Name = "������" };
                await context.Disciplines.AddAsync(discipline);
                await context.SaveChangesAsync();

                var disciplineService = new DisciplineService(context);
                discipline.Name = "���������� ������";

                await disciplineService.UpdateDisciplineAsync(discipline);

                var updatedDiscipline = await context.Disciplines.FindAsync(discipline.Id);

                Assert.NotNull(updatedDiscipline);
                Assert.Equal("���������� ������", updatedDiscipline.Name);
            }
        }

        [Fact]
        public async Task DeleteDisciplineAsync_DeletesDisciplineSuccessfully()
        {
            using (var context = new TeacherDbContext(_dbContextOptions))
            {
                var discipline = new Discipline { Name = "������� ����" };
                await context.Disciplines.AddAsync(discipline);
                await context.SaveChangesAsync();

                var disciplineService = new DisciplineService(context);
                await disciplineService.DeleteDisciplineAsync(discipline.Id);

                var deletedDiscipline = await context.Disciplines.FindAsync(discipline.Id);
                Assert.Null(deletedDiscipline);
            }
        }
    }
}
