using MediatR;
using TaskManagement.Application.Dtos;
using TaskManagement.Application.Interfaces;
using TaskManagement.Application.Requests;

namespace TaskManagement.Application.Handlers.Account
{
    public class MemberResetPasswordHandler : IRequestHandler<MemberResetPasswordRequest, Result<NoData>>
    {
        private readonly IUserRepository repository;

        public MemberResetPasswordHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<NoData>> Handle(MemberResetPasswordRequest request, CancellationToken cancellationToken)
        {

            var updated = await repository.GetByFilterAsync(x => x.Id == request.Id, false);
            if (updated == null)
                return new Result<NoData>(new NoData(), false, "Member bulunamadı", null);

            updated.Password = "123";

            var rows = await repository.SaveChangesAsync();

            if (rows > 0)
                return new Result<NoData>(new NoData(), true, null, null);

            return new Result<NoData>(new NoData(), false, "bir hata oluştu", null);

        }
    }
}
