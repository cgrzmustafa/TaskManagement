using System.Linq.Expressions;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Interfaces
{
    public interface ITaskReportRepository
    {
        Task<List<TaskReport>?> GetAllByFilterAsync(Expression<Func<TaskReport, bool>> filter, bool asNoTracking = true);
        Task<TaskReport?> GetByFilter(Expression<Func<TaskReport, bool>> filter, bool asNoTracking = true);
        Task<int> CreateAsync(TaskReport taskReport);
        Task<int> DeleteAsync(TaskReport taskReport);
        Task<int> SaveChangesAsync();
    }
}
