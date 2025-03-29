using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ServiceOrderCreatorApi.Models;

namespace ServiceOrderCreatorApi.Data
{
    public class ApplicationDBContext(DbContextOptions dbContextOptions)
        : IdentityDbContext<User>(dbContextOptions)
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<IdentityRole> roles =
            [
                new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Name = "User", NormalizedName = "USER" },
            ];

            builder.Entity<IdentityRole>().HasData(roles);
        }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.ConfigureWarnings(warnings =>
        //         warnings.Ignore(RelationalEventId.PendingModelChangesWarning)
        //     );
        // }
    }
}
