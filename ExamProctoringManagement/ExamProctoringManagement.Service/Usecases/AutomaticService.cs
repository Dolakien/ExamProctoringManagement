using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ExamProctoringManagement.Service.Interfaces;


namespace ExamProctoringManagement.Service.Usecases
{
    public class AutomaticService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public AutomaticService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // Thực hiện công việc trong một scope mới
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var proctoringService = scope.ServiceProvider.GetRequiredService<IProctoringScheduleService>();
                    await proctoringService.ChangeAutomaticSlotStatus();
                    await proctoringService.ChangeAutomaticIsFinished();
                }

                // Chờ 10 phút trước khi lặp lại
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }
}
