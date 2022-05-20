using DrinksVendingMachine.Interfaces;

namespace DrinksVendingMachine.Models
{
   public class BaseAuthentication : IAuthentication
   {
      public bool Authenticate(int key)
      {
         if (key == 12345)
            return true;

         return false;
      }
   }
}
