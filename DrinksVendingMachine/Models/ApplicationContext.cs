using DrinksVendingMachine.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace DrinksVendingMachine.Models
{
   public class ApplicationContext : DbContext
   {
      public DbSet<DrinkType> DrinkTypes { get; set; }
      public DbSet<DrinkGroup> DrinkGroups { get; set; }
      public DbSet<Drink> Drinks { get; set; }
      public DbSet<Coin> Coins { get; set; }
      public DbSet<Image> Images { get; set; }

      public ApplicationContext() { }

      public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
         //optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|App_Data\\DVMDb.mdf;Integrated Security=True");
      }
   }
}
