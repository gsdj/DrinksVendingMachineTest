using DrinksVendingMachine.Models.DbModels;
using System.Collections.Generic;

namespace DrinksVendingMachine.Models.ViewModels
{
   public class BuyDrinkResult
   {
      public Drink Drink { get; set; }
      public IEnumerable<CoinsChangeViewModel> Coins { get; set; }
   }
}
