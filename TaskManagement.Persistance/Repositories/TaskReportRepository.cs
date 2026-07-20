using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Entities;
using TaskManagement.Persistance.Context;

namespace TaskManagement.Persistance.Repositories
{
    public class TaskReportRepository : ITaskReportRepository
    {
        private readonly TaskManagementContext context;

        public TaskReportRepository(TaskManagementContext context)
        {
            this.context = context;
        }
        public async Task<List<TaskReport>?> GetAllByFilterAsync(Expression<Func<TaskReport, bool>> filter, bool asNoTracking = true)
        {
            if (asNoTracking)
            {
                return await this.context.TaskReports.AsNoTracking
                    ().Where(filter).ToListAsync();
            }
            return await this.context.TaskReports.Where(filter).ToListAsync();
        }
    }
}
