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
            services.AddScoped<IExamRepository, ExamRepository>();
            services.AddScoped<IFormSlotRepository, FormSlotRepository>();
            services.AddScoped<IFormSwapRepository, FormSwapRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IGroupRoomRepository, GroupRoomRepository>();
            services.AddScoped<IProctoringScheduleRepository, ProctoringScheduleRepository>();
            services.AddScoped<IRegistrationFormRepository, RegistrationFormRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<ISemesterRepository, SemesterRepository>();
            services.AddScoped<ISlotRepository, SlotRepository>();
            services.AddScoped<ISlotRoomSubjectRepository, SlotRoomSubjectRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();


            // Add UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
