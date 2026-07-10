using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Entities;
using TaskManagement.Persistance.Context;

namespace TaskManagement.Persistance.Repositories
{
    public class PriorityRepository : IPriorityRepository
    {
        private readonly TaskManagementContext context;

        public PriorityRepository(TaskManagementContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateAsync(Priority priority)
        {
            this.context.Priorities.Add(priority);
            return await this.context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Priority priority)
        {
            this.context.Priorities.Remove(priority);
            await this.context.SaveChangesAsync();
        }

        public async Task<List<Priority>> GetAllAsync()
        {
            return await this.context.Priorities.AsNoTracking().ToListAsync();
        }

        public async Task<Priority?> GetByFilterAsync(Expression<Func<Priority, bool>> filter)
        {
            return await this.context.Priorities.SingleOrDefaultAsync(filter);
        }

        public async Task<Priority?> GetByFilterAsNoTrackingAsync(Expression<Func<Priority, bool>> filter)
        {
            return await this.context.Priorities.AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await this.context.SaveChangesAsync();
        }
    }
}
