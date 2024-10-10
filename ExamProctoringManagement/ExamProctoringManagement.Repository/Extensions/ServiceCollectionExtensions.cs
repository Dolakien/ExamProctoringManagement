using Microsoft.Extensions.DependencyInjection;
using ExamProctoringManagement.Repository.Interfaces;
using ExamProctoringManagement.Repository.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamProctoringManagement.Repository.Repositories;

namespace ExamProctoringManagement.Repository.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositoryLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ServiceProfile));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();



            // Add UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
