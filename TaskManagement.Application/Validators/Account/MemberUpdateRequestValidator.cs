using FluentValidation;
using TaskManagement.Application.Requests;

namespace TaskManagement.Application.Validators.Account
{
    public class MemberUpdateRequestValidator : AbstractValidator<MemberUpdateRequest>
    {
        public MemberUpdateRequestValidator()
        {
            this.RuleFor(x => x.Name).NotEmpty().WithMessage("Ad boş geçilemez");
            this.RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad boş geçilemez");
        }
    }
}
