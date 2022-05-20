namespace DrinksVendingMachine.Interfaces.Services.Drinks
{
   public interface IDrinksService
   {
      IDrinks Drinks { get; }
      IGroupsDrinks GroupDrinks { get; }
      ITypesDrinks TypesDrinks { get; }
   }
}
