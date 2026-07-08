using FluentValidation;
using TaskManagement.Application.Requests;

namespace TaskManagement.Application.Validators
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            this.RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı boş geçilemez");
            this.RuleFor(x => x.Password).NotEmpty().WithMessage("Parola boş geçilemez");

        }
    }
}
