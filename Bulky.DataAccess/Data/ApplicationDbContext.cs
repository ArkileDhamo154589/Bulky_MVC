using Bulky.Models;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAcess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
                );
            
            modelBuilder.Entity<Product>().HasData(
                new Product { 
                    Id = 1,
                    Title = "Fortune of time",
                    Author = "Billy Spark",
                    Description = "Description added here",
                    ISBN = "SWD9999001",
                    ListPrice = 99,
                    Price = 90,
                    Price50 = 85, 
                    Price100 = 80
                },
                new Product
                {
                    Id = 1,
                    Title = "Fortune of time",
                    Author = "Billy Spark",
                    Description = "Description added here",
                    ISBN = "SWD9999001",
                    ListPrice = 99,
                    Price = 90,
                    Price50 = 85,
                    Price100 = 80
                    },
                new Product
                {
                    Id = 2,
                    Title = "Why you need to learn JS",
                    Author = "Achilleas Dhamo",
                    Description = "Learn everything about js from beginner to pro",
                    ISBN = "SWD9999002",
                    ListPrice = 99,
                    Price = 90,
                    Price50 = 85,
                    Price100 = 80
                },
                new Product
                {
                    Id = 3,
                    Title = "Why you need to learn .NET",
                    Author = "Achilleas Dhamo",
                    Description = "Learn everything about .NET from beginner to pro",
                    ISBN = "SWD9999002",
                    ListPrice = 88,
                    Price = 85,
                    Price50 = 80,
                    Price100 = 70
                },
                new Product
                {
                    Id = 4,
                    Title = "Why you need to learn React.js",
                    Author = "Achilleas Dhamo",
                    Description = "Learn everything about react from beginner to pro",
                    ISBN = "SWD9999002",
                    ListPrice = 88,
                    Price = 85,
                    Price50 = 80,
                    Price100 = 70
                },
                new Product
                {
                    Id = 5,
                    Title = "Why you need to learn html , css",
                    Author = "Achilleas Dhamo",
                    Description = "Learn everything about html css  from beginner to pro",
                    ISBN = "SWD9999002",
                    ListPrice = 88,
                    Price = 85,
                    Price50 = 80,
                    Price100 = 70
                }
            );
        }
     
    }
}
