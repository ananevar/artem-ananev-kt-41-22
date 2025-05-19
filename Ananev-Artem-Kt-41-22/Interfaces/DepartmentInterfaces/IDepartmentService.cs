﻿using Ananev_Artem_Kt_41_22.Filters.DepartmentFilters;
using Ananev_Artem_Kt_41_22.Models;

namespace Ananev_Artem_Kt_41_22.Interfaces.DepartmentInterfaces
{
    public interface IDepartmentService
    {
        Task<Department[]> GetDepartmentsAsync(DepartmentFilter filter, CancellationToken cancellationToken = default);
        Task AddDepartmentAsync(Department department, CancellationToken cancellationToken = default);
        Task UpdateDepartmentAsync(Department department, CancellationToken cancellationToken = default);
        Task<bool> DeleteDepartmentAsync(int departmentId, CancellationToken cancellationToken = default);
    }
}