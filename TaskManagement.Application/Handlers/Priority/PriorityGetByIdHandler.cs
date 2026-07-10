using MediatR;
using TaskManagement.Application.Dtos;
using TaskManagement.Application.Interfaces;
using TaskManagement.Application.Requests;

namespace TaskManagement.Application.Handlers
{
    public class PriorityGetByIdHandler : IRequestHandler<PriorityGetByIdRequest, Result<PriorityListDto>>
    {
        private readonly IPriorityRepository repository;

        public PriorityGetByIdHandler(IPriorityRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<PriorityListDto>> Handle(PriorityGetByIdRequest request, CancellationToken cancellationToken)
        {
            var priority = await this.repository.GetByFilterAsNoTrackingAsync(x => x.Id == request.Id);
            if (priority != null)
            {
                return new Result<PriorityListDto>(new PriorityListDto(priority.Id, priority.Definiton), true, null, null);
            }
            return new Result<PriorityListDto>(new PriorityListDto(0, ""), false, "Priority bulunamadı", null);
        }
    }
}
