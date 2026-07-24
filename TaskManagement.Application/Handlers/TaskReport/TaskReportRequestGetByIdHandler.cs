using MediatR;
using TaskManagement.Application.Dtos;
using TaskManagement.Application.Extensions;
using TaskManagement.Application.Interfaces;
using TaskManagement.Application.Requests;

namespace TaskManagement.Application.Handlers.TaskReport
{
    public class TaskReportRequestGetByIdHandler : IRequestHandler<TaskReportGetByIdRequest, Result<TaskReportListDto>>
    {
        private readonly ITaskReportRepository repository;

        public TaskReportRequestGetByIdHandler(ITaskReportRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<TaskReportListDto>> Handle(TaskReportGetByIdRequest request, CancellationToken cancellationToken)
        {
            var result = await this.repository.GetByFilter(x => x.Id == request.Id, true);

            if (result == null)
            {
                return new Result<TaskReportListDto>(null, false, "Rapor bulunamadı", null);
            }

            var dto = new TaskReportListDto(
                result.Id,
                result.Definition,
                result.Detail,
                result.AppTaskId,
                result.AppTask?.Title
            );

            return new Result<TaskReportListDto>(dto, true, null, null);
        }
    }
}