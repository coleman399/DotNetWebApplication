using WebApp1.Models.CategoryModel;
using WebApp1.Models.InventoryModel;

namespace WebApp1.Data
{
    public class InventoryDbContext : DbContext
    {
        public DbSet<Inventory> Inventory { get; set; } = null!;
        public DbSet<Category> Category { get; set; } = null!;

        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventory>().ToTable("Inventory");
            modelBuilder.Entity<Category>().ToTable("Category");
        }
    }
}
