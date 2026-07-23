using FluentValidation;
using TaskManagement.Application.Requests;

namespace TaskManagement.Application.Validators.Account
{
    public class MemberCreateRequestValidator : AbstractValidator<MemberCreateRequest>
    {
        public MemberCreateRequestValidator()
        {
            this.RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı boş geçilemez");
            this.RuleFor(x => x.Name).NotEmpty().WithMessage("Ad boş geçilemez");
            this.RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad boş geçilemez");
        }
    }
}
