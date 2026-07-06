using System.Linq.Expressions;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<AppUser?> GetByFilter(Expression<Func<AppUser, bool>> filter, bool asNoTracking = true);
    }
}
