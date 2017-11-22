using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using demobackend.Models;
using demobackend.Data;

namespace demobackend.Data{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> cars {get;set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {  
            builder.Entity<Car>()
            .ToTable("Car");
        
            builder.Entity<Car>()
            .Property(b => b.Id )
            .ValueGeneratedOnAdd();
            
            builder.Entity<Car>()
            .HasKey(b => b.Id );

            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
