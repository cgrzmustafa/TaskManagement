using FluentValidation;
using TaskManagement.Application.Requests;

namespace TaskManagement.Application.Validators.Priority
{
    public class PriorityUpdateRequestValidator : AbstractValidator<PriorityUpdateRequest>
    {
        public PriorityUpdateRequestValidator()
        {
            this.RuleFor(x => x.Definition).NotEmpty().WithMessage("Tanım bilgisi boş olamaz");
        }
    }
}
