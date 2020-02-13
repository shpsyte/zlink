using System.Linq;
using Business.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.Context {
    public class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int> {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base (options) { }

        public DbSet<Tag> Tag { get; set; }
        public DbSet<TagData> TagData { get; set; }

        protected override void OnModelCreating (ModelBuilder builder) {
            base.OnModelCreating (builder);

            builder.AddConfigContext ();
            // builder.LoadIdentity ();

        }

    }
}