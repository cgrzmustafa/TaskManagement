using System.Linq.Expressions;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Interfaces
{
    public interface ITaskReportRepository
    {
        Task<List<TaskReport>?> GetAllByFilterAsync(Expression<Func<TaskReport, bool>> filter, bool asNoTracking = true);
    }
}
