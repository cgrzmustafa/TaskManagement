using MediatR;
using TaskManagement.Application.Dtos;
using TaskManagement.Application.Extensions;
using TaskManagement.Application.Interfaces;
using TaskManagement.Application.Requests;
using TaskManagement.Application.Validators.Account;

namespace TaskManagement.Application.Handlers.Account
{
    public class MemberUpdateHandler : IRequestHandler<MemberUpdateRequest, Result<NoData>>
    {
        private readonly IUserRepository repository;

        public MemberUpdateHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<NoData>> Handle(MemberUpdateRequest request, CancellationToken cancellationToken)
        {

            var validator = new MemberUpdateRequestValidator();
            var validationResult = validator.Validate(request);

            if (validationResult.IsValid)
            {
                var updated = await repository.GetByFilterAsync(x => x.Id == request.Id, false);
                if (updated == null)
                    return new Result<NoData>(new NoData(), false, "Member bulunamadı", null);

                updated.Name = request.Name;
                updated.Surname = request.Surname;

                var rows = await repository.SaveChangesAsync();

                if (rows > 0)
                    return new Result<NoData>(new NoData(), true, null, null);

                return new Result<NoData>(new NoData(), false, "bir hata oluştu", null);
            }
            else
            {
                return new Result<NoData>(new NoData(), false, null, validationResult.Errors.ToMap());
            }
        }
    }
}
