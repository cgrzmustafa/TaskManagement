using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TaskManagement.Application.Dtos;
using TaskManagement.Application.Enums;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Entities;
using TaskManagement.Persistance.Context;
using TaskManagement.Persistance.Extensions;

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

        public async Task<List<AppUser>?> GetAllByFilterAsync(Expression<Func<AppUser, bool>> filter, bool asNoTracking = true)
        {
            if (asNoTracking)
            {
                return await this.context.Users.AsNoTracking
                    ().Where(filter).ToListAsync();
            }
            return await this.context.Users.Where(filter).ToListAsync();
        }

        public async Task<PagedData<AppUser>> GetAllAsync(int activePage, string? s = null, int pageSize = 10)
        {
            var query = this.context.Users.Where(x=>x.AppRoleId == (int)RoleType.Member).AsQueryable();
            if (!string.IsNullOrEmpty(s))
            {
                query = query.Where(x => x.Name.ToLower().Contains(s.ToLower()) || x.Surname.ToLower().Contains(s.ToLower()));
            }

            var list = await query.AsNoTracking().ToPagedAsync(activePage, pageSize);
            return list;
        }

    }
}
