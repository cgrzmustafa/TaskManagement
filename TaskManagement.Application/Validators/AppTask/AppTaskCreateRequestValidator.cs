using FluentValidation;
using TaskManagement.Application.Requests;

namespace TaskManagement.Application.Validators
{
    public class AppTaskCreateRequestValidator : AbstractValidator<AppTaskCreateRequest>
    {
        public AppTaskCreateRequestValidator()
        {
            this.RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık bilgisi boş olamaz");
            this.RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama bilgisi boş olamaz");
        }
    }
}
