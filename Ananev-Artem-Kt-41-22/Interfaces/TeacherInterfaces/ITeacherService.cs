using Ananev_Artem_Kt_41_22.Filters.TeacherFilters;
using Ananev_Artem_Kt_41_22.Models;

namespace Ananev_Artem_Kt_41_22.Interfaces.TeachersInterfaces
{
    public interface ITeacherService
    {
        Task<Teacher[]> GetTeachersAsync(TeacherFilter filter, CancellationToken cancellationToken = default);
        Task AddTeacherAsync(Teacher teacher, CancellationToken cancellationToken = default);
        Task UpdateTeacherAsync(Teacher teacher, CancellationToken cancellationToken = default);
        Task DeleteTeacherAsync(int teacherId, CancellationToken cancellationToken = default);
    }
}