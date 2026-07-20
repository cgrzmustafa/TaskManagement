using MediatR;
using TaskManagement.Application.Dtos;
using TaskManagement.Application.Extensions;
using TaskManagement.Application.Interfaces;
using TaskManagement.Application.Requests;
using TaskManagement.Application.Validators.Priority;

namespace TaskManagement.Application.Handlers
{
    public class PriorityUpdateHandler : IRequestHandler<PriorityUpdateRequest, Result<NoData>>
    {
        private readonly IPriorityRepository repository;

        public PriorityUpdateHandler(IPriorityRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<NoData>> Handle(PriorityUpdateRequest request, CancellationToken cancellationToken)
        {
            var validator = new PriorityUpdateRequestValidator();
            var validationResult = validator.Validate(request);

            if (validationResult.IsValid)
            {
                var updatedEntity = await this.repository.GetByFilterAsync(x => x.Id == request.Id);
                if (updatedEntity == null)
                    return new Result<NoData>(new NoData(), false, "İlgili aciliyet bulunamadı", null);

                updatedEntity.Definiton = request.Definition ?? "";

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
