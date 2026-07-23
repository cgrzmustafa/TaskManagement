using MediatR;
using TaskManagement.Application.Dtos;
using TaskManagement.Application.Interfaces;
using TaskManagement.Application.Requests;

namespace TaskManagement.Application.Handlers.Notification
{
    public class NotificationUpdateHandler : IRequestHandler<NotificationUpdateRequest, Result<NoData>>
    {
        private readonly INotificationRepository repository;

        public NotificationUpdateHandler(INotificationRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<NoData>> Handle(NotificationUpdateRequest request, CancellationToken cancellationToken)
        {
            var updated = await this.repository.GetByFilterAsync(x => x.Id == request.Id);
            if (updated == null)
                return new Result<NoData>(new NoData(), false, "Bildirim bulunamadı", null);
            updated.State = true;
            await this.repository.SaveChangeAsync();

            return new Result<NoData>(new NoData(), true, null, null);

        }
    }
}
