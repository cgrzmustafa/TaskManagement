using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<AppUser?> GetByFilter(Expression<Func<AppUser, bool>> filter, bool asNoTracking = true)
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
