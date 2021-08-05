using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ErrorCenter.Models;

namespace ErrorCenter.Data
{
    public class ErrorCenterContext : DbContext
    {
        public ErrorCenterContext (DbContextOptions<ErrorCenterContext> options)
            : base(options)
        {
        }

        public DbSet<ErrorCenter.Models.Error> Error { get; set; } 
        public DbSet<ErrorCenter.Models.User> User { get; set; }

    }
}
