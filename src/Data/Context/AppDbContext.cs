using System.Linq;
using Business.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Context {
    public class AppDbContext : DbContext {

        public DbSet<Tag> Tag { get; set; }
        public DbSet<TagData> TagData { get; set; }
        public AppDbContext (DbContextOptions options) : base (options) { }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            //muda o comportamento de todas as colunas string para varchar(100)
            foreach (var item in modelBuilder.Model.GetEntityTypes ()
                    .SelectMany (a => a.GetProperties ()
                        .Where (p => p.ClrType == typeof (string)))) {
                item.Relational ().ColumnType = "varchar(100)";

            }

            //Faz o carregamento auto das classes
            modelBuilder.ApplyConfigurationsFromAssembly (typeof (AppDbContext).Assembly);

            base.OnModelCreating (modelBuilder);
        }

    }
}