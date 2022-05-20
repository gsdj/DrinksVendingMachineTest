using DrinksVendingMachine.Models.DbModels;
using System.Collections.Generic;

namespace DrinksVendingMachine.Models.ViewModels
{
   public class BuyModel
   {
      public int Id { get; set; }
      public List<CoinViewModel> Coins { get; set; } 
      public int Sum { get; set; }
   }
}
