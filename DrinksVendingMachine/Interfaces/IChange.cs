using DrinksVendingMachine.Models.ViewModels;
using System.Collections.Generic;

namespace DrinksVendingMachine.Interfaces
{
   public interface IChange
   {
      IEnumerable<CoinsChangeViewModel> GetChange(int sum, int drinkPrice);
   }
}
