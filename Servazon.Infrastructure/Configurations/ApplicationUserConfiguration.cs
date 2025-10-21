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
    internal class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(u => u.FullName)
                   .HasMaxLength(150)
                   .IsRequired();

            builder.HasOne(u => u.ProviderProfile)
                   .WithOne(p => p.User)
                   .HasForeignKey<ProviderProfile>(p => p.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.ClientRequests)
                   .WithOne(r => r.Client)
                   .HasForeignKey(r => r.ClientId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.Notifications)
                   .WithOne(n => n.User)
                   .HasForeignKey(n => n.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
