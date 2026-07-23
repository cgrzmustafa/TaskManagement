using MediatR;
using TaskManagement.Application.Dtos;
using TaskManagement.Application.Interfaces;
using TaskManagement.Application.Requests;

namespace TaskManagement.Application.Handlers.Account
{
    public class MemberGetByIdHandler : IRequestHandler<MemberGetByIdRequest, Result<MemberListDto>>
    {
        private readonly IUserRepository repository;

        public MemberGetByIdHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<MemberListDto?>> Handle(MemberGetByIdRequest request, CancellationToken cancellationToken)
        {
            var result = await this.repository.GetByFilterAsync(x => x.Id == request.Id);

            if (result != null)
                return new Result<MemberListDto?>(new MemberListDto(result.Id, result.Name, result.Surname, result.Username), true, null, null);
            return new Result<MemberListDto?>(null, false, "", null);

        }
    }
}
