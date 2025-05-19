using Ananev_Artem_Kt_41_22.Filters.LoadFilters;
using Ananev_Artem_Kt_41_22.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Ananev_Artem_Kt_41_22.Interfaces.LoadInterfaces
{
    public interface ILoadService
    {
        Task<Load[]> GetLoadsAsync(LoadFilter filter, CancellationToken cancellationToken = default);
        Task AddLoadAsync(Load load, CancellationToken cancellationToken = default);
        Task UpdateLoadAsync(Load load, CancellationToken cancellationToken = default);
    }
}