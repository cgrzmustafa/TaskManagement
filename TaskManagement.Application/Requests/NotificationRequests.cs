using MediatR;
using TaskManagement.Application.Dtos;

namespace TaskManagement.Application.Requests
{
    public record NotificationListByUserIdRequest(int UserId) : IRequest<Result<List<NotificationListDto>>>;
    public record NotificationUpdateRequest(int Id) : IRequest<Result<NoData>>;
}
