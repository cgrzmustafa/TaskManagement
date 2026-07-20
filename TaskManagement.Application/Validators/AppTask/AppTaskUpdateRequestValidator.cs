using FluentValidation;
using TaskManagement.Application.Requests;

namespace TaskManagement.Application.Validators.AppTask
{
    public class AppTaskUpdateRequestValidator : AbstractValidator<AppTaskUpdateRequest>
    {
        public AppTaskUpdateRequestValidator()
        {
            this.RuleFor(x => x.PriorityId).NotEmpty().WithMessage("Öncelik bilgisi boş geçilemez");
            this.RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık bilgisi boş olamaz");
            this.RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama bilgisi boş olamaz");
        }
    }
}
