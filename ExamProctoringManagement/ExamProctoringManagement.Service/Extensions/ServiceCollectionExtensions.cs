using ExamProctoringManagement.Service.Authentication;
using ExamProctoringManagement.Service.Interfaces;
using ExamProctoringManagement.Service.Services;
using ExamProctoringManagement.Service.Usecases;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Service.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IJwtProvider, JwtProvider>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IClaimsPrincipalExtensions, ClaimsPrincipalExtensions>();


            return services;
        }
    }
}
