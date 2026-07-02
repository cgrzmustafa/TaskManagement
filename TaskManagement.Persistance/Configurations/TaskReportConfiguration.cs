using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Persistance.Configurations
{
    public class TaskReportConfiguration : IEntityTypeConfiguration<TaskReport>
    {
        public void Configure(EntityTypeBuilder<TaskReport> builder)
        {
            builder.Property(x => x.Detail).IsRequired(true);

            builder.Property(x => x.Definition).IsRequired(true);
            builder.Property(x => x.Definition).HasMaxLength(250);

            builder.Property(x => x.AppTaskId).IsRequired(true);
        }
    }
}
