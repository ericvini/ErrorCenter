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
            
            var context = new ErrorCenterContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ErrorCenterContext>>());

            var UserContext = new UserCenterContext(
                    serviceProvider.GetRequiredService<
                        DbContextOptions<UserCenterContext>>());

            // Look for any movies.
            if (context.Error.Any() && UserContext.User.Any())
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
        

            //using (var UserContext = new UserCenterContext(
            //        serviceProvider.GetRequiredService<
            //            DbContextOptions<UserCenterContext>>()))
            //{
            //    // Look for any movies.
            //    if (UserContext.User.Any())
            //    {
            //        return;   // DB has been seeded
            //    }

                UserContext.User.AddRange(
                    new User
                    {
                        Name = "Admin",
                        Email = "Admin@mybad.com",
                        Password = "Teste123",
                    },

                    new User
                    {
                        Name = "Teste1",
                        Email = "teste1@mybad.com",
                        Password = "Teste123",
                    },

                    new User
                    {
                        Name = "Teste2",
                        Email = "teste2@mybad.com",
                        Password = "Teste123",
                    }
                );
                UserContext.SaveChanges();
            //}
        }
    }
}