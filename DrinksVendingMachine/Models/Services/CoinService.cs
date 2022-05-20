using DrinksVendingMachine.Interfaces.Services;
using DrinksVendingMachine.Models.DbModels;
using System.Collections.Generic;
using System.Linq;

namespace DrinksVendingMachine.Models.Services
{
   public class CoinService : ICoinService
   {
      private readonly ApplicationContext Db;
      public CoinService(ApplicationContext context)
      {
         Db = context;
      }

      public void Block(int id)
      {
         var coin = Db.Coins.FirstOrDefault(p => p.Id == id);

         if (coin.IsBlocked == 0)
            coin.IsBlocked = 1;

         if (coin.IsBlocked == 1)
            coin.IsBlocked = 0;

         Db.Coins.Update(coin);

         Db.SaveChanges();
      }

      public void Delete(int id)
      {
         var c = Db.Coins.Find(id);
         Db.Coins.Remove(c);
         Db.SaveChanges();
      }

      public Coin Get(int id)
      {
         return Db.Coins.Find(id);
      }

      public IEnumerable<Coin> GetAll()
      {
         return Db.Coins;
      }

      public void Save(Coin model)
      {
         Db.Coins.Add(model);
         Db.SaveChanges();
      }
   }
}
