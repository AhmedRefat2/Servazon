using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Servazon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servazon.Infrastructure.Configurations
{
    internal class AI_ClassificationLogConfiguration : IEntityTypeConfiguration<AI_ClassificationLog>
    {
        public void Configure(EntityTypeBuilder<AI_ClassificationLog> builder)
        {
            builder.Property(a => a.InputText)
                   .HasMaxLength(1000);

            builder.Property(a => a.PredictedCategory)
                   .HasMaxLength(100);

            builder.Property(a => a.ConfidenceScore)
                   .HasColumnType("float");
        }
    }
}
