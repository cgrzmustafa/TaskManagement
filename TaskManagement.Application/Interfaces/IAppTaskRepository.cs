using System.Linq.Expressions;
using TaskManagement.Application.Dtos;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Interfaces
{
    public interface IAppTaskRepository
    {
        Task<PagedData<AppTask>> GetAllAsync(int activePage, string? s = null, int pageSize = 10);
        Task<int> CreateAsync(AppTask task);
        Task DeleteAsync(AppTask deleted);
        Task<AppTask?> GetByFilterAsync(Expression<Func<AppTask, bool>> filter);
        Task<AppTask?> GetByFilterAsNoTrackingAsync(Expression<Func<AppTask, bool>> filter);
        Task<int> SaveChangesAsync();
    }
}
