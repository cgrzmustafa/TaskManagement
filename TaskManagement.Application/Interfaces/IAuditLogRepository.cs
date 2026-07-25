using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Interfaces
{
    public interface IAuditLogRepository
    {
        Task AddAsync(AuditLog auditLog);
        Task SaveChangesAsync();
    }
}