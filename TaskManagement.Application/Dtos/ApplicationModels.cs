using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Dtos
{
    public record Result<T>(T Data, bool IsSuccess, string? ErrorMessge, List<ValidationError>? Errors);
    public record ValidationError(string PropertyName, string ErrorMessage);
    public record NoData();
}
