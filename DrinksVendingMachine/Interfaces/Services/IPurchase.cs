namespace DrinksVendingMachine.Interfaces.Services
{
   public interface IPurchase<Tin,Tout>
   {
      Tout Buy(Tin model);
   }
}
