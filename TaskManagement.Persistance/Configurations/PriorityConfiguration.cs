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
    public class PriorityConfiguration : IEntityTypeConfiguration<Priority>
    {
        public void Configure(EntityTypeBuilder<Priority> builder)
        {
            builder.Property(x => x.Definiton).IsRequired(true);
            builder.Property(x => x.Definiton).HasMaxLength(250);

            builder.HasMany(x => x.Tasks).WithOne(x => x.Priority).HasForeignKey(x => x.PriorityId);
        }
    }
}
