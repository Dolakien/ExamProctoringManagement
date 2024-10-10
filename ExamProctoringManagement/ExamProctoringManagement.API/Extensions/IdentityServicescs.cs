using ExamProctoringManagement.API.OptionalSetup;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace ExamProctoringManagement.API.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection IdentityServices(this IServiceCollection services)
        {
            services.ConfigureOptions<JwtOptionsSetup>();
            services.ConfigureOptions<JwtBearerOptionsSetup>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt => {
                opt.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context => {
                        var accesssToken = context.Request.Query["access_token"];
                        var path = context.HttpContext.Request.Path;
                        if (!string.IsNullOrEmpty(accesssToken) && path.StartsWithSegments("/hubs"))
                        {
                            context.Token = accesssToken;
                        }
                        return Task.CompletedTask;
                    }
                };
            });

            return services;
        }

    }
}
