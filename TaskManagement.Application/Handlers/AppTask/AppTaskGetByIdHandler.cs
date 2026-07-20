using MediatR;
using TaskManagement.Application.Dtos;
using TaskManagement.Application.Extensions;
using TaskManagement.Application.Interfaces;
using TaskManagement.Application.Requests;

namespace TaskManagement.Application.Handlers.AppTask
{
    public class AppTaskGetByIdHandler : IRequestHandler<AppTaskGetByIdRequest, Result<AppTaskListDto>>
    {
        private readonly IAppTaskRepository repository;

        public AppTaskGetByIdHandler(IAppTaskRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<AppTaskListDto>> Handle(AppTaskGetByIdRequest request, CancellationToken cancellationToken)
        {
            var result = await this.repository.GetByFilterAsNoTrackingAsync(x => x.Id == request.Id);

            return new Result<AppTaskListDto>(result.ToMap(), true, null, null);
        }
    }
}
