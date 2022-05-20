using DrinksVendingMachine.Models.DbModels;
using System.Collections.Generic;

namespace DrinksVendingMachine.Interfaces.Services.Drinks
{
   public interface IDrinks : IBaseService<Drink>
   {
      void Block(int id);
      IEnumerable<Drink> GetByGroupId(int id);
   }
}
