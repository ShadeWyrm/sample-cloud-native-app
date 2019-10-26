using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GCCloudSample.Models
{
    public class GcDbContext : IdentityDbContext<ApplicationUser>
    {
        public GcDbContext(DbContextOptions<GcDbContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Review> Reviews { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<DepartmentService> DepartmentServices { get; set; }
    }
}