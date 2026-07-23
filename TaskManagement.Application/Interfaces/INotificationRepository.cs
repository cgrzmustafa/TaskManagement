using System.Linq.Expressions;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Interfaces
{
    public interface INotificationRepository
    {
        Task<int> SendNotification(Notification notification);
        Task<Notification?> GetByFilterAsync(Expression<Func<Notification, bool>> filter);
        Task<Notification?> GetByFilterAsNoTrackingAsync(Expression<Func<Notification, bool>> filter);
        Task<List<Notification>?> GetAllByFilterAsync(Expression<Func<Notification, bool>> filter, bool asNoTracking = true);
        Task<int> SaveChangeAsync();
    }
}
