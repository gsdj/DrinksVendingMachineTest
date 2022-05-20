using System.Collections.Generic;
using System.Linq;

namespace DrinksVendingMachine.Models.DbModels
{
   public class DrinkGroup
   {
      public DrinkGroup()
      {
         Drinks = new List<Drink>();
      }
      public int Id { get; set; }
      public string Name { get; set; }
      public int DrinkTypeId { get; set; }
      public int CountDrinks => Drinks.Sum(p => p.Count);
      public DrinkType DrinkType { get; set; }
      public List<Drink> Drinks { get; set; }
   }
}
