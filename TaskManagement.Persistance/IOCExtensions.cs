using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Application.Interfaces;
using TaskManagement.Persistance.Context;
using TaskManagement.Persistance.Repositories;

namespace TaskManagement.Persistance
{
    public static class IOCExtensions
    {
        public static void AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TaskManagementContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Local"));
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPriorityRepository, PriorityRepository>();
            services.AddScoped<IAppTaskRepository, AppTaskRepository>();
            services.AddScoped<ITaskReportRepository, TaskReportRepository>();
        }
    }
}
