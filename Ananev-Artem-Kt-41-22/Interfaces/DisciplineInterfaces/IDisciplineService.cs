using Ananev_Artem_Kt_41_22.Filters.DisciplineFilters;
using Ananev_Artem_Kt_41_22.Models;

namespace Ananev_Artem_Kt_41_22.Interfaces.DisciplineInterfaces
{
    public interface IDisciplineService
    {
        Task<Discipline[]> GetDisciplinesByHeadIdAsync(HeadIdDisciplineFilter filter, CancellationToken cancellationToken = default);
        Task<Discipline[]> GetDisciplinesAsync(DisciplineFilter filter, CancellationToken cancellationToken = default);
        Task AddDisciplineAsync(Discipline discipline, CancellationToken cancellationToken = default);
        Task UpdateDisciplineAsync(Discipline discipline, CancellationToken cancellationToken = default);
        Task DeleteDisciplineAsync(int disciplineId, CancellationToken cancellationToken = default);
    }
}