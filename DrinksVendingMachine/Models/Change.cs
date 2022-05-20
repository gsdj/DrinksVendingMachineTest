using DrinksVendingMachine.Interfaces;
using DrinksVendingMachine.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace DrinksVendingMachine.Models
{
   public class Change : IChange
   {
      private readonly ApplicationContext Db;
      public Change(ApplicationContext context)
      {
         Db = context;
      }
      public IEnumerable<CoinsChangeViewModel> GetChange(int sum, int drinkPrice)
      {
         int change = sum - drinkPrice;
         List<CoinsChangeViewModel> cc = new List<CoinsChangeViewModel>();
         if (change > 0)
         {
            var coins = Db.Coins.Where(p => p.IsBlocked == 0).AsQueryable();
            int[] coinsDenomination = coins.OrderByDescending(p => p.CoinDenomination).Select(p => p.CoinDenomination).ToArray();

            foreach (int item in coinsDenomination)
            {
               if (change == 0)
                  break;

               int a = change / item;
               if (a > 0)
               {
                  coins.FirstOrDefault(p => p.CoinDenomination == item).Count -= a;
                  cc.Add(new CoinsChangeViewModel { CoinDen = item, CoinCount = a });
                  change = change - item * a;
               }
            }
            Db.Coins.UpdateRange(coins);
            Db.SaveChanges();
         }
         return cc;
      }
   }
}
