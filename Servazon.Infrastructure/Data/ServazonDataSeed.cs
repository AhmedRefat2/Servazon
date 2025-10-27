using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Servazon.Domain.Entities;
using Servazon.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servazon.Infrastructure.Data
{
    public static class ServazonDataSeed
    {
        public static async Task SeedAsync(ServazonDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            // Seed Users 
            if (!dbContext.Users.Any())
            {
                var users = new List<ApplicationUser>
                {
                    new ApplicationUser { Id = "user-1", FullName = "أحمد محمد", UserName = "ahmed1", Email = "ahmed1@example.com", IsActive = true },
                    new ApplicationUser { Id = "user-2", FullName = "سارة علي", UserName = "sara", Email = "sara@example.com", IsActive = true },
                    new ApplicationUser { Id = "user-3", FullName = "محمد حسن", UserName = "mohamed", Email = "mohamed@example.com", IsActive = true },
                    new ApplicationUser { Id = "user-4", FullName = "منى محمود", UserName = "mona", Email = "mona@example.com", IsActive = true }
                };

                foreach (var user in users)
                    await userManager.CreateAsync(user, "Servazon@123");
            }

            // 2️ Seed Categories
            if (!dbContext.ServiceCategories.Any())
            {
                var categories = new List<ServiceCategory>
                {
                    new ServiceCategory { Name = "سباكة", Description = "خدمات الصرف الصحي والمياه", BasePrice = 150 },
                    new ServiceCategory { Name = "كهرباء", Description = "خدمات الكهرباء المنزلية والصناعية", BasePrice = 200 },
                    new ServiceCategory { Name = "نجارة", Description = "صيانة وتصليح الأثاث والأبواب", BasePrice = 180 },
                    new ServiceCategory { Name = "دهان", Description = "دهانات وتشطيبات المنازل", BasePrice = 250 },
                    new ServiceCategory { Name = "تصميم داخلي", Description = "تصميم وديكور للمنازل والمكاتب", BasePrice = 400 }
                };
                dbContext.ServiceCategories.AddRange(categories);
                await dbContext.SaveChangesAsync();
            }

            // 3️ Seed Providers
            if (!dbContext.ProviderProfiles.Any())
            {
                var providers = new List<ProviderProfile>
                {
                    new ProviderProfile { UserId = "user-2", Bio = "سباكة عامة بخبرة 5 سنوات", ExperienceYears = 5, WorkArea = "الجيزة", Rating = 4.7m, Balance = 1200, IsVerified = true },
                    new ProviderProfile { UserId = "user-3", Bio = "كهربائي متخصص بالمنازل", ExperienceYears = 7, WorkArea = "القاهرة", Rating = 4.9m, Balance = 800, IsVerified = true }
                };
                dbContext.ProviderProfiles.AddRange(providers);
                await dbContext.SaveChangesAsync();
            }

            // 4️ Seed Service Requests
            if (!dbContext.ServiceRequests.Any())
            {
                var requests = new List<ServiceRequest>
                {
                    new ServiceRequest
                    {
                        ClientId = "user-1",
                        ProviderId = 1,
                        CategoryId = 1,
                        Description = "تصليح تسريب مياه في الحمام",
                        Price = 180,
                        Status = RequestStatus.Completed,
                        CreatedAt = DateTime.UtcNow.AddDays(-5),
                        ScheduledFor = DateTime.UtcNow.AddDays(-4),
                        CompletedAt = DateTime.UtcNow.AddDays(-3)
                    },
                    new ServiceRequest
                    {
                        ClientId = "user-4",
                        ProviderId = 2,
                        CategoryId = 2,
                        Description = "تركيب مفتاح كهرباء جديد",
                        Price = 220,
                        Status = RequestStatus.InProgress,
                        CreatedAt = DateTime.UtcNow.AddDays(-2),
                        ScheduledFor = DateTime.UtcNow.AddDays(-1)
                    }
                };
                dbContext.ServiceRequests.AddRange(requests);
                await dbContext.SaveChangesAsync();
            }

            // 5️⃣Seed Feedback
            if (!dbContext.Feedbacks.Any())
            {
                var feedbacks = new List<Feedback>
                {
                    new Feedback { RequestId = 1, ClientId = "user-1", Rating = 5, Comment = "شغل ممتاز جدًا وسريع!", CreatedAt = DateTime.UtcNow.AddDays(-2) },
                    new Feedback { RequestId = 2, ClientId = "user-4", Rating = 4, Comment = "الكهربائي محترم جدًا لكن اتأخر شويه.", CreatedAt = DateTime.UtcNow.AddDays(-1) }
                };
                dbContext.Feedbacks.AddRange(feedbacks);
                await dbContext.SaveChangesAsync();
            }

            // 6️ Seed Payments
            if (!dbContext.Payments.Any())
            {
                var payments = new List<Payment>
                {
                    new Payment { RequestId = 1, Amount = 180, Method = "Cash", Status = "Paid", TransactionId = "TXN1001", PaidAt = DateTime.UtcNow.AddDays(-3) },
                    new Payment { RequestId = 2, Amount = 220, Method = "Card", Status = "Pending", TransactionId = "TXN1002", PaidAt = DateTime.UtcNow }
                };
                dbContext.Payments.AddRange(payments);
                await dbContext.SaveChangesAsync();
            }

            // 7️ Seed Notifications
            if (!dbContext.Notifications.Any())
            {
                var notifications = new List<Notification>
                {
                    new Notification { UserId = "user-1", Title = "تم قبول طلبك", Message = "مزود الخدمة بدأ تنفيذ الطلب رقم 1", CreatedAt = DateTime.UtcNow.AddDays(-4) },
                    new Notification { UserId = "user-4", Title = "طلبك قيد التنفيذ", Message = "الكهربائي بدأ العمل على طلبك رقم 2", CreatedAt = DateTime.UtcNow.AddDays(-1) }
                };
                dbContext.Notifications.AddRange(notifications);
                await dbContext.SaveChangesAsync();
            }

            // 8️ Seed AI Classification Logs
            if (!dbContext.AI_ClassificationLogs.Any())
            {
                var logs = new List<AI_ClassificationLog>
                {
                    new AI_ClassificationLog { RequestId = 1, InputText = "تصليح حنفية الحمام", PredictedCategory = "سباكة", ConfidenceScore = 0.95m },
                    new AI_ClassificationLog { RequestId = 2, InputText = "تركيب مفتاح كهرباء", PredictedCategory = "كهرباء", ConfidenceScore = 0.93m }
                };
                dbContext.AI_ClassificationLogs.AddRange(logs);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
