using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Dtos;
using TaskManagement.Application.Extensions;
using TaskManagement.Application.Interfaces;
using TaskManagement.Application.Requests;
using TaskManagement.Application.Validators.Priority;
using TaskManagement.Application.Validators.TaskReport;

namespace TaskManagement.Application.Handlers.TaskReport
{
    public class TaskReportUpdateHandler : IRequestHandler<TaskReportUpdateRequest, Result<NoData>>
    {
        private readonly ITaskReportRepository repository;

        public TaskReportUpdateHandler(ITaskReportRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<NoData>> Handle(TaskReportUpdateRequest request, CancellationToken cancellationToken)
        {
            var validator = new TaskReportUpdateRequestValidator();
            var validationResult = validator.Validate(request);

            if (validationResult.IsValid)
            {
                var updatedEntity = await this.repository.GetByFilter(x => x.Id == request.Id, true);

                if (updatedEntity == null)
                    return new Result<NoData>(new NoData(), false, "Rapor bulunamadı", null);

                updatedEntity.Definition = request.Definition;
                updatedEntity.Detail = request.Detail;
                updatedEntity.AppTaskId = request.TaskId;

                await this.repository.SaveChangesAsync();
                return new Result<NoData>(new NoData(), true, null, null);
            }
            else
            {
                var errors = validationResult.Errors.ToMap();
                return new Result<NoData>(new NoData(), false, null, errors);
            }
        }
    }
}