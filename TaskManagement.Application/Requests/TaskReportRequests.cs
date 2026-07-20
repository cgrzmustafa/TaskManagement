using MediatR;
using TaskManagement.Application.Dtos;

namespace TaskManagement.Application.Requests
{
    public record TaskReportGetByTaskIdRequest(int Id) : IRequest<Result<List<TaskReportListDto>>>;
}
