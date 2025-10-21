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
    internal class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.Property(f => f.Comment)
                   .HasMaxLength(500);

            builder.Property(f => f.Rating)
                   .IsRequired();

            builder.HasOne(f => f.Client)
                   .WithMany()
                   .HasForeignKey(f => f.ClientId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
