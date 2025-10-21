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
    internal class ServiceRequestConfiguration : IEntityTypeConfiguration<ServiceRequest>
    {
        public void Configure(EntityTypeBuilder<ServiceRequest> builder)
        {
            builder.Property(r => r.Description)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(r => r.Price)
                   .HasColumnType("decimal(10,2)");

            builder.HasOne(r => r.Client)
                   .WithMany(u => u.ClientRequests)
                   .HasForeignKey(r => r.ClientId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.Provider)
                   .WithMany(p => p.ServiceRequests)
                   .HasForeignKey(r => r.ProviderId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.Category)
                   .WithMany(c => c.ServiceRequests)
                   .HasForeignKey(r => r.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.Feedback)
                   .WithOne(f => f.Request)
                   .HasForeignKey<Feedback>(f => f.RequestId);

            builder.HasOne(r => r.Payment)
                   .WithOne(p => p.Request)
                   .HasForeignKey<Payment>(p => p.RequestId);

            builder.HasOne(r => r.AI_ClassificationLog)
                   .WithOne(a => a.Request)
                   .HasForeignKey<AI_ClassificationLog>(a => a.RequestId);
        }
    }
}
