using Ananev_Artem_Kt_41_22.DB;
using Microsoft.EntityFrameworkCore;
using Ananev_Artem_Kt_41_22.Middlewares;
using Ananev_Artem_Kt_41_22.Interfaces.TeachersInterfaces;
using Ananev_Artem_Kt_41_22.ServiceExtensions;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NLog;
using NLog.Web;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

try
{
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();
    // Add services to the container.

    builder.Services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            options.JsonSerializerOptions.MaxDepth = 32; // ?????????? ???????????? ??????? ?? ?????????????
        });
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddDbContext<TeacherDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    builder.Services.AddServices();
    builder.Services.AddMvc();
    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseAuthorization();

    app.UseMiddleware<ExceptionHandlerMiddleware>();

    app.MapControllers();

    app.Run();
}

catch(Exception ex)
{
    logger.Error(ex, "Stopped program because exception");
}
finally
{
    LogManager.Shutdown();
}