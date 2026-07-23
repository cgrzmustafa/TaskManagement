using MediatR;
using TaskManagement.Application.Dtos;
using TaskManagement.Application.Enums;
using TaskManagement.Application.Interfaces;
using TaskManagement.Application.Requests;
namespace TaskManagement.Application.Handlers.Dashboard
{
    public class DashboardHandler : IRequestHandler<DashboardRequest, Result<DashboardDto>>
    {
        private readonly IAppTaskRepository taskRepository;
        private readonly IUserRepository userRepository;
        private readonly INotificationRepository notificationRepository;
        public DashboardHandler(IAppTaskRepository taskRepository, IUserRepository userRepository, INotificationRepository notificationRepository)
        {
            this.taskRepository = taskRepository;
            this.userRepository = userRepository;
            this.notificationRepository = notificationRepository;
        }
        public async Task<Result<DashboardDto>> Handle(DashboardRequest request, CancellationToken cancellationToken)
        {
            var taskResult = await this.taskRepository.GetAllByFilter(x => true) ?? new List<TaskManagement.Domain.Entities.AppTask>();
            var taskCount = taskResult.Count();

            var userResult = await this.userRepository.GetAllByFilterAsync(x => x.AppRoleId == (int)RoleType.Member);
            var userCount = userResult.Count();

            var notificationResult = await this.notificationRepository.GetAllByFilterAsync(x => x.State == false && x.AppUserId == request.UserId);
            var notificationCount = notificationResult.Count();

            var tasksByStatus = taskResult
                .GroupBy(x => x.State)
                .Select(g => new ChartItemDto(g.Key ? "Tamamlandı" : "Tamamlanmadı", g.Count()))
                .ToList();

            var tasksByPriority = taskResult
                .GroupBy(x => x.Priority != null ? x.Priority.Definiton : "Tanımsız")
                .Select(g => new ChartItemDto(g.Key, g.Count()))
                .OrderByDescending(x => x.Value)
                .ToList();

            var tasksByUser = taskResult
                .GroupBy(x => x.AppUser != null ? $"{x.AppUser.Name} {x.AppUser.Surname}" : "Atanmamış")
                .Select(g => new ChartItemDto(g.Key, g.Count()))
                .OrderByDescending(x => x.Value)
                .Take(8)
                .ToList();

            return new Result<DashboardDto>(
                new DashboardDto(taskCount, userCount, notificationCount, tasksByStatus, tasksByPriority, tasksByUser),
                true, null, null);
        }
    }
}