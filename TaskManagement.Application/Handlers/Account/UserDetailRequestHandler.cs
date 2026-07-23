using MediatR;
using TaskManagement.Application.Dtos;
using TaskManagement.Application.Interfaces;
using TaskManagement.Application.Requests;

namespace TaskManagement.Application.Handlers.Account
{
    public class UserDetailRequestHandler : IRequestHandler<UserDetailRequest, Result<UserDetailDto>>
    {
        private readonly IUserRepository repository;

        public UserDetailRequestHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<UserDetailDto>> Handle(UserDetailRequest request, CancellationToken cancellationToken)
        {
            var user = await this.repository.GetByFilterAsync(x => x.Id == request.Id, false);

            if (user == null)
            {
                return new Result<UserDetailDto>(default, false, "Kullanıcı bulunamadı", null);
            }

            var dto = new UserDetailDto(user.Id, user.Name, user.Surname, user.Password);

            return new Result<UserDetailDto>(dto, true, null, null);
        }
    }
}