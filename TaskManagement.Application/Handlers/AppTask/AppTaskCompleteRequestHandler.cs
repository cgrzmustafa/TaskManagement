using MediatR;
using TaskManagement.Application.Dtos;
using TaskManagement.Application.Interfaces;
using TaskManagement.Application.Requests;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Handlers.AppTask
{
    public class AppTaskCompleteRequestHandler : IRequestHandler<AppTaskCompleteRequest, Result<NoData>>
    {
        private readonly IAppTaskRepository appTaskRepository;
        private readonly INotificationRepository notificationRepository;
        private readonly IAuditLogRepository auditLogRepository; 

        public AppTaskCompleteRequestHandler(
            IAppTaskRepository appTaskRepository,
            INotificationRepository notificationRepository,
            IAuditLogRepository auditLogRepository)
        {
            this.appTaskRepository = appTaskRepository;
            this.notificationRepository = notificationRepository;
            this.auditLogRepository = auditLogRepository;
        }

        public async Task<Result<NoData>> Handle(AppTaskCompleteRequest request, CancellationToken cancellationToken)
        {
            var updated = await this.appTaskRepository.GetByFilterAsync(x => x.Id == request.Id);
            updated.State = true;

            await this.appTaskRepository.SaveChangesAsync();

            await this.notificationRepository.SendNotification(new Domain.Entities.Notification
            {
                State = false,
                AppUserId = 1,
                Description = $"{updated.Title} adlı iş emri tamamlandı",
            });

            await this.auditLogRepository.AddAsync(new AuditLog
            {
                Action = "COMPLETE",
                TableName = "AppTasks",
                UserId = updated.AppUserId ?? 0,
                UserName = "Member User",
                Details = $"{updated.Id} ID'li '{updated.Title}' başlıklı iş emri tamamlandı.",
                CreatedDate = DateTime.Now
            });

            await this.auditLogRepository.SaveChangesAsync();

            return new Result<NoData>(new NoData(), true, null, null);
        }
    }
}