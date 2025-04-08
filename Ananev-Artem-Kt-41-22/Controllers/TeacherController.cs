using Microsoft.AspNetCore.Mvc;
using Ananev_Artem_Kt_41_22.Filters.TeacherInterfaces;
using Ananev_Artem_Kt_41_22.Interfaces.TeacherInterfaces;

namespace Ananev_Artem_Kt_41_22.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly ILogger<TeacherController> _logger;
        private readonly ITeacherService _teacherService;

        public TeacherController(ILogger<TeacherController> logger, ITeacherService teacherService)
        {
            _logger = logger;
            _teacherService = teacherService;
        }

        [HttpPost("GetTeachers")]
        public async Task<IActionResult> GetTeachersByCathedraAsync(TeacherDepartmentFilter filter, CancellationToken cancellationToken = default)
        {
            var teachers = await _teacherService.GetTeachersByCathedraAsync(filter, cancellationToken);
            return Ok(teachers);
        }
    }
}