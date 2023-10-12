using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pet.Database.Models;

namespace Pet.Database
{

    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<BaseInformation> BaseInformations { get; set; }
        public DbSet<Brother> Brothers { get; set; }
        public DbSet<Sister> Sisters { get; set; }
        public DbSet<Parent> Parents { get; set; }

        public DbSet<Color> Colors { get; set; }

        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {

        }
       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // RoleSeeder.Seed(builder);
            //UserSeed.Seed(builder);

        }
    }

}