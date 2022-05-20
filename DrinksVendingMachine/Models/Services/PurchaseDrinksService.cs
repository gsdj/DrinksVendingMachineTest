using DrinksVendingMachine.Interfaces;
using DrinksVendingMachine.Interfaces.Services;
using DrinksVendingMachine.Models.DbModels;
using DrinksVendingMachine.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace DrinksVendingMachine.Models.Services
{
   public class PurchaseDrinksService : IPurchaseDrinksService
   {
      private readonly ApplicationContext Db;
      private IChange Change;
      public PurchaseDrinksService(ApplicationContext context, IChange change)
      {
         Db = context;
         Change = change;
      }
      public BuyDrinkResult Buy(BuyModel model)
      {
         BuyDrinkResult result = new BuyDrinkResult();

         if (model.Id > 0 && model.Sum > 0)
         {
            var drink = Db.Drinks.Find(model.Id);
            if (drink.Price <= model.Sum)
            {
               //var coins = Db.Coins.Where(p => p.IsBlocked == 0).ToList();
               var coins = Db.Coins.Where(p => p.IsBlocked == 0).AsQueryable();

               drink.Count--;
               foreach (var item in model.Coins)
               {
                  coins.FirstOrDefault(p => p.CoinDenomination == item.CoinDenomination).Count += item.Count;
               }
               Db.UpdateRange(coins);
               //coins.FirstOrDefault(p => p.CoinDenomination == 1).Count += model.Coin1;
               //coins.FirstOrDefault(p => p.CoinDenomination == 2).Count += model.Coin2;
               //coins.FirstOrDefault(p => p.CoinDenomination == 5).Count += model.Coin5;
               //coins.FirstOrDefault(p => p.CoinDenomination == 10).Count += model.Coin10;
               Db.SaveChanges();

               result.Drink = drink;

               result.Coins = Change.GetChange(model.Sum, drink.Price);
            }
         }
         return result;
      }

      public List<Coin> GetAllCoins()
      {
         return Db.Coins.Where(p => p.IsBlocked == 0).ToList();
      }

      public List<Drink> GetAllDrinks()
      {
         return Db.Drinks.Where(p => p.IsBlocked == 0 && p.Count > 1).ToList();
      }
   }
}
