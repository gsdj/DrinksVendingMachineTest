using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DrinksVendingMachine.Models.DbModels
{
   public class DrinkType
   {
      public DrinkType()
      {
         DrinkGroups = new List<DrinkGroup>();
      }
      public int Id { get; set; }
      public string Name { get; set; }
      public string Description { get; set; }
      public List<DrinkGroup> DrinkGroups { get; set; }

   }
}
