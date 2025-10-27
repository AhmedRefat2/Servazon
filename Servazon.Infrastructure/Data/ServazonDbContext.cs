using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Servazon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Servazon.Infrastructure.Data
{
    public class ServazonDbContext : IdentityDbContext<ApplicationUser>
    {
        public ServazonDbContext(DbContextOptions<ServazonDbContext> servazonOptions) : base(servazonOptions)
        {

        }
        
        #region Db Sets 
        public DbSet<ProviderProfile> ProviderProfiles { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<ServiceRequest> ServiceRequests { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<AI_ClassificationLog> AI_ClassificationLogs { get; set; }

        // Note There Are No DbSet for ApplicationUser as it is Managed by IdentityDbContext

        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("auth");


           foreach(var entity in builder.Model.GetEntityTypes())
            {
                var tableName = entity.GetTableName();
                if (tableName?.StartsWith("AspNet") ?? false)
                    entity.SetSchema("auth");
                else
                    entity.SetSchema("core");
            }

            builder.ApplyConfigurationsFromAssembly(typeof(ServazonDbContext).Assembly); // Apply all configurations from the current assembly [Infrastructure]

            base.OnModelCreating(builder);
        }

    }
}
