using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.DAO.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDAOLayer(this IServiceCollection services, IConfiguration configuration)
        {
            //Add DBContext
            //services.AddDbContext<>(opt =>
            //{
            //    configure the options for this Database

            //   opt.UseSqlServer(configuration["ConnectionString:DefaultConnection"]);
            //});

            return services;
        }
    }
}
