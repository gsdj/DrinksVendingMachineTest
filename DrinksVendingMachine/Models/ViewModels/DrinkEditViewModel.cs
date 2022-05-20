using DrinksVendingMachine.Models.DbModels;
using System.Collections.Generic;

namespace DrinksVendingMachine.Models.ViewModels
{
   public class DrinkEditViewModel
   {
      public Drink Drink { get; set; }
      public List<Image> Images { get; set; }
   }
}
