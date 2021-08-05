using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ErrorCenter.Data;
using System;
using System.Linq;
using ErrorCenter.Models;

namespace ErrorCenter.Models
{
    public class SeedData
    {
        private ErrorCenterContext _context;

            public SeedData(ErrorCenterContext context)
             {
              _context = context;
             }

            public void Seed()
        {
            // Look for any movies.
            if (_context.Error.Any() || _context.User.Any())
            {
                return;   // DB has been seeded
            }

            User u1 = new User("Éric", "eric@gmail.com", "123");
            User u2 = new User("Anderson", "anderson@gmail.com", "123");
            User u3 = new User("Emerson", "emerson@gmail.com", "123");

            Error e1 = new Error
             (
                 "accelaration.Service.AddCandidate",
                 "user.Controller",
                 1,
                 "Error",
                 u1
             );

            Error e2 = new Error
          (
              "accelaration.Service.AddCandidate",
              "user.Controller",
              1,
              "Error",
              u2
          );

            Error e3 = new Error
                            (
                                "accelaration.Service.AddCandidate",
                                "user.Controller",
                                1,
                                "Error",
                                u3
                            );

            Error e4 = new Error
             (
                 "accelaration.Service.AddCandidate",
                 "user.Controller",
                 1,
                 "Error",
                 u2
             );

            _context.User.AddRange(u1, u2, u3);

            _context.Error.AddRange(e1, e2, e3, e4);



            _context.SaveChanges();

        }


    }
}