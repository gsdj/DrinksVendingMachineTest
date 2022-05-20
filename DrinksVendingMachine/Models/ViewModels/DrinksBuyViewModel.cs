using DrinksVendingMachine.Models.DbModels;
using System.Collections.Generic;

namespace DrinksVendingMachine.Models.ViewModels
{
   public class DrinksBuyViewModel
   {
      public List<Coin> Coins { get; set; }
      public List<Drink> Drinks { get; set; }
   }
}
