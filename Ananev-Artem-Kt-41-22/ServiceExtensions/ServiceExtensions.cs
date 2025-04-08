using Ananev_Artem_Kt_41_22.Interfaces.TeacherInterfaces;
namespace Ananev_Artem_Kt_41_22.ServiceExtensions

{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITeacherService, TeacherService>();
            return services;
        }
    }
}