using BulkyRazorProject.Model;
using Microsoft.EntityFrameworkCore;
namespace BulkyRazorProject.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Aryan Patel", DisplayOrder = "1" },
                new Category { Id = 2, Name = "Anjali Patel", DisplayOrder = "2" },
                new Category { Id = 3, Name = "Aman Patel", DisplayOrder = "3" }
                );
        }
    }
}
