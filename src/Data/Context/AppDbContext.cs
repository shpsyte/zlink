using System.Linq;
using Business.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Context {
    public class AppDbContext : DbContext {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base (options) { }

        public DbSet<Tag> Tag { get; set; }
        public DbSet<TagData> TagData { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            base.OnModelCreating (modelBuilder);

            modelBuilder.AddConfigContext ();

        }

    }
}