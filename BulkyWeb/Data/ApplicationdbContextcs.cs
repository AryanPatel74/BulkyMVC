using Microsoft.EntityFrameworkCore;
using BulkyWeb.Models;
namespace BulkyWeb.Data
{
    public class ApplicationdbContextcs : DbContext
    {
        public ApplicationdbContextcs(DbContextOptions<ApplicationdbContextcs> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id=1, Name="Aryan Patel", DisplayOrder="1"},
                new Category { Id=2, Name="Anjali Patel", DisplayOrder="2"},
                new Category { Id=3, Name="Aman Patel", DisplayOrder="3"}
                );
        }
    }
    
}
