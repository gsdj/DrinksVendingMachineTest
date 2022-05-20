using DrinksVendingMachine.Interfaces.Services.Drinks;
using DrinksVendingMachine.Models.DbModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DrinksVendingMachine.Models.Services.Drinks
{
   public class Drinks : IDrinks
   {
      private readonly ApplicationContext Db;
      public Drinks(ApplicationContext context)
      {
         Db = context;
      }

      public void Block(int id)
      {
         var drink = Db.Drinks.FirstOrDefault(p => p.Id == id);

         if (drink.IsBlocked == 0)
            drink.IsBlocked = 1;

         if (drink.IsBlocked == 1)
            drink.IsBlocked = 0;

         Db.Drinks.Update(drink);

         Db.SaveChanges();
      }

      public void Delete(int id)
      {
         var d1 = Db.Drinks.Find(id);
         Db.Drinks.Remove(d1);
         Db.SaveChanges();
      }

      public Drink Get(int id)
      {
         return Db.Drinks.Include(p => p.DrinkGroup).FirstOrDefault(p => p.Id == id);
      }

      public IEnumerable<Drink> GetAll()
      {
         return Db.Drinks;
      }

      public IEnumerable<Drink> GetByGroupId(int id)
      {
         return Db.Drinks.Include(p => p.DrinkGroup).ThenInclude(p => p.DrinkType).Where(p => p.DrinkGroup.Id == id).ToList();
      }

      public void Save(Drink model)
      {
         if (model.Id == 0)
         {
            Db.Drinks.Add(model);
         }
         else
         {
            var m = Db.Drinks.Find(model.Id);

            m.Name = model.Name;
            m.Description = model.Description;
            m.Volume = model.Volume;
            m.Price = model.Price;
            m.Count = model.Count;
            m.ImageUrl = model.ImageUrl;

            Db.Drinks.Update(m);
         }

         Db.SaveChanges();
      }
   }

}
