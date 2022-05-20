using DrinksVendingMachine.Interfaces.Services.Drinks;
using DrinksVendingMachine.Models.DbModels;
using System.Collections.Generic;

namespace DrinksVendingMachine.Models.Services.Drinks
{
   public class TypesDrinks : ITypesDrinks
   {
      private readonly ApplicationContext Db;
      public TypesDrinks(ApplicationContext context)
      {
         Db = context;
      }
      public void Delete(int id)
      {
         var t = Db.DrinkTypes.Find(id);
         Db.DrinkTypes.Remove(t);
         Db.SaveChanges();
      }

      public DrinkType Get(int id)
      {
         return Db.DrinkTypes.Find(id);
      }

      public IEnumerable<DrinkType> GetAll()
      {
         return Db.DrinkTypes;
      }

      public void Save(DrinkType model)
      {
         Db.DrinkTypes.Add(model);
         Db.SaveChanges();
      }
   }
}
