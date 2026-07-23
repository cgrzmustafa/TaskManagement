using MediatR;
using TaskManagement.Application.Dtos;
using TaskManagement.Application.Enums;
using TaskManagement.Application.Extensions;
using TaskManagement.Application.Interfaces;
using TaskManagement.Application.Requests;
using TaskManagement.Application.Validators;

namespace TaskManagement.Application.Handlers
{
    public class LoginRequestHandler : IRequestHandler<LoginRequest, Result<LoginResponseDto?>>
    {
        private readonly IUserRepository userRepository;

        public LoginRequestHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<Result<LoginResponseDto?>> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var validator = new LoginRequestValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.IsValid)
            {
                var user = await this.userRepository.GetByFilterAsync(x => x.Password == request.Password && x.Username == request.Username);


                if (user != null)
                {
                    var type = (RoleType)user.AppRoleId;
                    return new Result<LoginResponseDto?>(new LoginResponseDto(user.Name, user.Surname, type, user.Id), true, null, null);
                }
                else
                {
                    return new Result<LoginResponseDto?>(null, false, "Kullanıcı adı veya şifre hatalı", null);
                }
            }
            else
            {
                var errorList = validationResult.Errors.ToMap();
                return new Result<LoginResponseDto?>(null, false, null, errorList);
            }
        }
    }
}
