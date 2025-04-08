using Ananev_Artem_Kt_41_22.DB;
using Ananev_Artem_Kt_41_22.Models;
using Microsoft.EntityFrameworkCore;
using Ananev_Artem_Kt_41_22.Filters.TeacherInterfaces;

namespace Ananev_Artem_Kt_41_22.Interfaces.TeacherInterfaces
{
    public interface ITeacherService
    {
        public Task<Teacher[]> GetTeachersByCathedraAsync(TeacherDepartmentFilter filter, CancellationToken cancellationToken);
    }

    public class TeacherService : ITeacherService
    {
        private readonly TeacherDbContext _dbContext;

        public TeacherService(TeacherDbContext dbContext)
        {
            _dbContext = dbContext;
        }

public async Task<Teacher[]> GetTeachersByCathedraAsync(TeacherDepartmentFilter filter, CancellationToken cancellationToken)
{
    var teachers = await _dbContext.Teachers
        .Where(t => t.Department.Name == filter.DepartmentName)
        .ToArrayAsync(cancellationToken);

    return teachers;
}
    }
}