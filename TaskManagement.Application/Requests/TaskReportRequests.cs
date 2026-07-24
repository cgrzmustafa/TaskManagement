using MediatR;
using TaskManagement.Application.Dtos;

namespace TaskManagement.Application.Requests
{
    public record TaskReportGetByTaskIdRequest(int Id) : IRequest<Result<List<TaskReportListDto>>>;
    public record TaskReportGetByIdRequest(int Id) : IRequest<Result<TaskReportListDto>>;
    public record TaskReportCreateRequest(string? Detail, string? Definition, int TaskId) : IRequest<Result<NoData>>;

    public class TaskReportUpdateRequest : IRequest<Result<NoData>>
    {
        public int Id { get; set; }
        public string? Detail { get; set; }
        public string? Definition { get; set; }
        public int TaskId { get; set; }
    }

    public record TaskReportDeleteRequest(int Id) : IRequest<Result<NoData>>;
}