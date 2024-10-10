using ExamProctoringManagement.API.Middleware;
using FluentValidation;
using System.Reflection.Metadata;

namespace ExamProctoringManagement.API.Extensions { 

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
IConfiguration config)
    {
        services.AddCors();
        services.AddSignalR();
        services.AddValidatorsFromAssembly(AssemblyReference.Assembly);
        services.AddScoped<ExecuteValidation>();

        return services;


    }
}
}
