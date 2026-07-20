using MediatR;
using TaskManagement.Application.Dtos;
using TaskManagement.Application.Extensions;
using TaskManagement.Application.Interfaces;
using TaskManagement.Application.Requests;

namespace TaskManagement.Application.Handlers.TaskReport
{
    public class TaskReportRequestHandler : IRequestHandler<TaskReportGetByTaskIdRequest, Result<List<TaskReportListDto>>>
    {
        private readonly ITaskReportRepository repository;

        public TaskReportRequestHandler(ITaskReportRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<List<TaskReportListDto>>> Handle(TaskReportGetByTaskIdRequest request, CancellationToken cancellationToken)
        {
            var result = await this.repository.GetAllByFilterAsync(x => x.AppTaskId == request.Id, false);
            return new Result<List<TaskReportListDto>>(result.ToMap(), true, null, null);
        }
    }
}
