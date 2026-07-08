using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Application.Requests;

namespace TaskManagement.Application.Extensions
{
    public static class IOCExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(LoginRequest).Assembly));
        }
    }
}
