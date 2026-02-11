using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using BeautySuitePro.Api.Data;
using BeautySuitePro.Api.Models;

namespace BeautySuitePro.Data
{
    public static class DbSeeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            context.Database.Migrate();

            // Seed Users
            if (!context.Users.Any())
            {
                var adminId = Guid.NewGuid();
                var customerId = Guid.NewGuid();
                var floristId = Guid.NewGuid();

                context.Users.AddRange(
                    new User
                    {
                        Id = adminId,
                        FirstName = "System",
                        LastName = "Admin",
                        Email = "admin@blossom.com",
                        PasswordHash = "hashedpassword",
                        Role = "Admin",
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    },
                    new User
                    {
                        Id = customerId,
                        FirstName = "John",
                        LastName = "Doe",
                        Email = "customer@blossom.com",
                        PasswordHash = "hashedpassword",
                        Role = "Customer",
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    },
                    new User
                    {
                        Id = floristId,
                        FirstName = "Lily",
                        LastName = "Smith",
                        Email = "florist@blossom.com",
                        PasswordHash = "hashedpassword",
                        Role = "Florist",
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    }
                );
                context.SaveChanges();
            }

            // Seed Currencies
            if (!context.Currencies.Any())
            {
                context.Currencies.AddRange(
                    new Currency
                    {
                        Id = Guid.NewGuid(),
                        Code = "GBP",
                        Name = "British Pound",
                        Symbol = "£",
                        IsActive = true
                    },
                    new Currency
                    {
                        Id = Guid.NewGuid(),
                        Code = "USD",
                        Name = "US Dollar",
                        Symbol = "$",
                        IsActive = true
                    }
                );
                context.SaveChanges();
            }

            // Seed GiftCards
            if (!context.GiftCards.Any())
            {
                context.GiftCards.Add(
                    new GiftCard
                    {
                        Id = Guid.NewGuid(),
                        Code = "WELCOME10",
                        InitialAmount = 10,
                        RemainingAmount = 10,
                        ExpiryDate = DateTime.UtcNow.AddMonths(6),
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
