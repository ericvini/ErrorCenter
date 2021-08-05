using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ErrorCenter.Models;

namespace ErrorCenter.Data
{
    public class UserCenterContext : DbContext
    {
        public UserCenterContext (DbContextOptions<UserCenterContext> options)
            : base(options)
        {
        }

        public DbSet<ErrorCenter.Models.User> User { get; set; }
    }
}
