using FluentValidation;
using TaskManagement.Application.Requests;

namespace TaskManagement.Application.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            this.RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı boş geçilemez");
            this.RuleFor(x => x.Password).NotEmpty().WithMessage("Parola boş geçilemez");
            this.RuleFor(x => x.Name).NotEmpty().WithMessage("İsim boş geçilemez");
            this.RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyisim boş geçilemez");
            this.RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("Parolalar eşleşmiyor");
        }
    }
}
