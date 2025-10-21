using Microsoft.EntityFrameworkCore;
using Servazon.Infrastructure.Data;

namespace Servazon.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region 1. Register Services at Dependancy Injection Container

            builder.Services.AddControllersWithViews(); // MVC Pattern

            builder.Services.AddDbContext<ServazonDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ServazonLocalConnectionString")));


            #endregion

            var app = builder.Build();

            #region Update Database - Apply Pending Migrations Automatically & Log Errors


            using var scope = app.Services.CreateScope();
            var loggerFactory = scope.ServiceProvider.GetRequiredService<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger<Program>();

            try
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ServazonDbContext>();
                dbContext.Database.Migrate();
                logger.LogInformation("Database migrated successfully.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while migrating or initializing the database.");
            }   

            #endregion

            #region 2. Configure Middlewares 

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            #endregion

            app.Run();
        }
    }
}
