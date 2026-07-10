using MediatR;
using TaskManagement.Application.Dtos;
using TaskManagement.Application.Interfaces;
using TaskManagement.Application.Requests;

namespace TaskManagement.Application.Handlers
{
    public class PriorityListHandler : IRequestHandler<PriorityListRequest, Result<List<PriorityListDto>>>
    {
        private readonly IPriorityRepository repository;

        public PriorityListHandler(IPriorityRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<List<PriorityListDto>>> Handle(PriorityListRequest request, CancellationToken cancellationToken)
        {
            var result = await this.repository.GetAllAsync();

            var mappedResult = result.Select(x => new PriorityListDto(x.Id, x.Definiton)).ToList();
            return new Result<List<PriorityListDto>>(mappedResult, true, null, null);
        }
    }
}
