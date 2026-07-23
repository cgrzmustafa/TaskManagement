using MediatR;
using TaskManagement.Application.Dtos;
using TaskManagement.Application.Interfaces;
using TaskManagement.Application.Requests;

namespace TaskManagement.Application.Handlers.Account
{
    public class MemberDeleteHandler : IRequestHandler<MemberDeleteRequest, Result<NoData>>
    {
        private readonly IUserRepository repository;

        public MemberDeleteHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<NoData>> Handle(MemberDeleteRequest request, CancellationToken cancellationToken)
        {
            var deleted = await this.repository.GetByFilterAsync(x => x.Id == request.Id, false);
            if (deleted == null)
                return new Result<NoData>(new NoData(), false, "Member bulunamadı", null);

            await this.repository.DeleteAsync(deleted);
            return new Result<NoData>(new NoData(), true, null, null);
        }
    }
}
