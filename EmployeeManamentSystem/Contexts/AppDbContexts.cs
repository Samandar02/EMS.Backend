using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhileLearnAsp.NetCoreApp.Contexts
{
    public class AppDbContexts:IdentityDbContext<IdentityUser>
    {
        public AppDbContexts(DbContextOptions<AppDbContexts> options) : base(options)
        {

        }
        public DbSet<Models.Managment> Managments { get; set; }
        public DbSet<Models.Employee> Employees { get; set; }


    }
}
