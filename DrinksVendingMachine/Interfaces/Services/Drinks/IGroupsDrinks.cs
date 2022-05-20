using DrinksVendingMachine.Models.DbModels;
using System.Collections.Generic;

namespace DrinksVendingMachine.Interfaces.Services.Drinks
{
   public interface IGroupsDrinks : IBaseService<DrinkGroup>
   {
      IEnumerable<DrinkGroup> GetByTypeId(int id);
   }
}
