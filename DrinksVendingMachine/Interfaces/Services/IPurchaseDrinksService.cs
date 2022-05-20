using DrinksVendingMachine.Models.DbModels;
using DrinksVendingMachine.Models.ViewModels;
using System.Collections.Generic;

namespace DrinksVendingMachine.Interfaces.Services
{
   public interface IPurchaseDrinksService : IPurchase<BuyModel, BuyDrinkResult>
   {
      List<Drink> GetAllDrinks();
      List<Coin> GetAllCoins();
   }
}
