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
    internal class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.Property(p => p.Amount)
                   .HasColumnType("decimal(10,2)");

            builder.Property(p => p.Method)
                   .HasMaxLength(50);

            builder.Property(p => p.Status)
                   .HasMaxLength(50);

            builder.Property(p => p.TransactionId)
                   .HasMaxLength(100);
        }
    }
}
