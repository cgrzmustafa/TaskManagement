using System.Linq.Expressions;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Interfaces
{
    public interface IPriorityRepository
    {
        Task<List<Priority>> GetAllAsync();
        Task<int> CreateAsync(Priority priority);
        Task<Priority?> GetByFilterAsNoTrackingAsync(Expression<Func<Priority, bool>> filter);
        Task<Priority?> GetByFilterAsync(Expression<Func<Priority, bool>> filter);
        Task DeleteAsync(Priority priority);
        Task<int> SaveChangesAsync();
    }
}
