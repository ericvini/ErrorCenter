using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ErrorCenter.Data;
using System;
using System.Linq;

namespace ErrorCenter.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ErrorCenterContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ErrorCenterContext>>()))
            {
                // Look for any movies.
                if (context.Error.Any())
                {
                    return;   // DB has been seeded
                }

                context.Error.AddRange(
                    new Error
                    {
                        Title = "accelaration.Service.AddCandidate",
                        Description = "user.Controller",
                        EventsCount = 1,
                        Level = "Error"
                    },

                    new Error
                    {
                        Title = "accelaration.Service.AddCandidate",
                        Description = "user.Service.Auth:password",
                        EventsCount = 10,
                        Level = "Error"
                    },

                    new Error
                    {
                        Title = "accelaration.Service.RemoveCandidate",
                        Description = "user.Controller",
                        EventsCount = 1000,
                        Level = "Warning"
                    },

                    new Error
                    {
                        Title = "accelaration.Service.RemoveAdmin",
                        Description = "Auth:password",
                        EventsCount = 1000,
                        Level = "Debug"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}