using Microsoft.EntityFrameworkCore;
using P06Shop.Shared.Shop;
using P07Shop.DataSeeder;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace P05Shop.API.Models
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Shoe> Shoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // fluent api 
            modelBuilder.Entity<Shoe>().HasKey(p => p.Id);

            modelBuilder.Entity<Shoe>()
                .Property(p => p.Id)
                .IsRequired();

            modelBuilder.Entity<Shoe>()
                .Property(p => p.ShoeSize)
                .IsRequired();

            modelBuilder.Entity<Shoe>()
             .Property(p => p.Description)
             .HasMaxLength(200);

            modelBuilder.Entity<Shoe>()
            .Property(p => p.Name)
            .HasMaxLength(100);


            // data seed 

            modelBuilder.Entity<Shoe>().HasData(ShoeSeeder.GenerateShoeData());
        }
    }
}
// instalacja dotnet ef 
//dotnet tool install --global dotnet-ef

// aktualizacja 
//dotnet tool update --global dotnet-ef

// dotnet ef migrations add [nazwa_migracji]
// dotnet ef database update 


// cofniecie migraji niezaplikowanych 
//dotnet ef migrations remove