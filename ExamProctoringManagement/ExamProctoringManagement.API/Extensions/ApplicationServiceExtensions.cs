using ExamProctoringManagement.API.Middleware;

namespace ExamProctoringManagement.API.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
IConfiguration config)
    {
        services.AddCors();
        services.AddSignalR();
        services.AddScoped<ExecuteValidation>();
        return services;


    }
}
