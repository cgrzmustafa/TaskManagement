using FluentValidation;
using TaskManagement.Application.Requests;

namespace TaskManagement.Application.Validators.Account
{
    public class UserDetailUpdateRequestValidator : AbstractValidator<UserDetailUpdateRequest>
    {
        public UserDetailUpdateRequestValidator()
        {
            this.RuleFor(x => x.Password).NotEmpty().WithMessage("Parola boş geçilemez");
            this.RuleFor(x => x.Name).NotEmpty().WithMessage("Ad boş geçilemez");
            this.RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad boş geçilemez");
        }
    }
}
