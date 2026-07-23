using MediatR;
using TaskManagement.Application.Dtos;
namespace TaskManagement.Application.Requests
{
    public record DashboardRequest(int UserId) : IRequest<Result<DashboardDto>>;
}