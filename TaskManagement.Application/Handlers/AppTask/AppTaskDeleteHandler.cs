using MediatR;
using TaskManagement.Application.Dtos;
using TaskManagement.Application.Interfaces;
using TaskManagement.Application.Requests;

namespace TaskManagement.Application.Handlers.AppTask
{
    public class AppTaskDeleteHandler : IRequestHandler<AppTaskDeleteRequest, Result<NoData>>
    {
        private readonly IAppTaskRepository repository;

        public AppTaskDeleteHandler(IAppTaskRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<NoData>> Handle(AppTaskDeleteRequest request, CancellationToken cancellationToken)
        {
            var deletedAppTask = await this.repository.GetByFilterAsync(x => x.Id == request.Id);
            await this.repository.DeleteAsync(deletedAppTask);

            return new Result<NoData>(new NoData(), true, null, null);
        }
    }
}
