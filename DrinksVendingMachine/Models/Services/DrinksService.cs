using DrinksVendingMachine.Interfaces.Services.Drinks;

namespace DrinksVendingMachine.Models.Services
{
   public class DrinksService : IDrinksService
   {
      public DrinksService(ITypesDrinks tpd, IGroupsDrinks gpd, IDrinks d)
      {
         TypesDrinks = tpd;
         GroupDrinks = gpd;
         Drinks = d;
      }
      public IDrinks Drinks { get; private set; }

      public IGroupsDrinks GroupDrinks { get; private set; }

      public ITypesDrinks TypesDrinks { get; private set; }
   }
}
