using DrinksVendingMachine.Models.DbModels;

namespace DrinksVendingMachine.Interfaces.Services
{
   public interface ICoinService : IBaseService<Coin> 
   {
      void Block(int id);
   }
}
