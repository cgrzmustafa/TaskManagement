using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Entities;
using TaskManagement.Persistance.Context;

namespace TaskManagement.Persistance.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskManagementContext context;

        public UserRepository(TaskManagementContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateUserAsync(AppUser user)
        {
            this.context.Users.Add(user);
            return await this.context.SaveChangesAsync();
        }
        public async Task<AppUser?> GetByFilterAsync(Expression<Func<AppUser, bool>> filter, bool asNoTracking = true)
        {
            if (asNoTracking)
            {
                return await this.context.Users.AsNoTracking
                    ().SingleOrDefaultAsync(filter);
            }
            return await this.context.Users.SingleOrDefaultAsync(filter);
        }

    }
}
