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
    internal class ProviderProfileConfiguration : IEntityTypeConfiguration<ProviderProfile>
    {
        public void Configure(EntityTypeBuilder<ProviderProfile> builder)
        {
            builder.Property(p => p.Bio)
                   .HasMaxLength(500);

            builder.Property(p => p.WorkArea)
                   .HasMaxLength(100);

            builder.Property(p => p.Balance)
                   .HasColumnType("decimal(10,2)");

            builder.Property(p => p.Rating)
                   .HasColumnType("decimal(3,2)");
        }
    }
}
