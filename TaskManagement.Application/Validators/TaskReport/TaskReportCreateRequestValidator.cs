using FluentValidation;
using TaskManagement.Application.Requests;

namespace TaskManagement.Application.Validators.TaskReport
{
    public class TaskReportCreateRequestValidator : AbstractValidator<TaskReportCreateRequest>
    {
        public TaskReportCreateRequestValidator()
        {
            this.RuleFor(x => x.Detail).NotEmpty().WithMessage("Açıklama bilgisi boş olamaz");
            this.RuleFor(x => x.Definition).NotEmpty().WithMessage("Başlık bilgisi boş olamaz");
        }
    }
}
