using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Entities;
using TaskManagement.Persistance.Context;

namespace TaskManagement.Persistance.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly TaskManagementContext context;

        public NotificationRepository(TaskManagementContext context)
        {
            this.context = context;
        }
        public async Task<List<Notification>?> GetAllByFilterAsync(Expression<Func<Notification, bool>> filter, bool asNoTracking = true)
        {
            if (asNoTracking)
            {
                return await this.context.Notifications.AsNoTracking
                    ().Where(filter).OrderByDescending(x => x.Id).ToListAsync();
            }
            return await this.context.Notifications.Where(filter).OrderByDescending(x => x.Id).ToListAsync();
        }

        public async Task<Notification?> GetByFilterAsNoTrackingAsync(Expression<Func<Notification, bool>> filter)
        {
            return await this.context.Notifications.AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task<Notification?> GetByFilterAsync(Expression<Func<Notification, bool>> filter)
        {
            return await this.context.Notifications.SingleOrDefaultAsync(filter);
        }

        public async Task<int> SaveChangeAsync()
        {
            return await this.context.SaveChangesAsync();
        }

        public async Task<int> SendNotification(Notification notification)
        {
            await this.context.AddAsync(notification);
            return await this.context.SaveChangesAsync();
        }
    }
}
