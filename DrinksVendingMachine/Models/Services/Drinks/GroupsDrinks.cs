using DrinksVendingMachine.Interfaces.Services.Drinks;
using DrinksVendingMachine.Models.DbModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DrinksVendingMachine.Models.Services.Drinks
{
   public class GroupsDrinks : IGroupsDrinks
   {
      private readonly ApplicationContext Db;
      public GroupsDrinks(ApplicationContext context)
      {
         Db = context;
      }
      public void Delete(int id)
      {
         var gr = Db.DrinkGroups.Find(id);
         Db.DrinkGroups.Remove(gr);
         Db.SaveChanges();
      }

      public DrinkGroup Get(int id)
      {
         return Db.DrinkGroups.Find(id);
      }

      public IEnumerable<DrinkGroup> GetAll()
      {
         return Db.DrinkGroups;
      }

      public IEnumerable<DrinkGroup> GetByTypeId(int id)
      {
         return Db.DrinkGroups.Include(p => p.DrinkType).Where(p => p.DrinkType.Id == id).Include(p => p.Drinks).ToList();
      }

      public void Save(DrinkGroup model)
      {
         Db.DrinkGroups.Add(model);
         Db.SaveChanges();
      }
   }
}
