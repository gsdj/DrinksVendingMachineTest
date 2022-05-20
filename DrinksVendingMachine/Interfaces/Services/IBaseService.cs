using System.Collections.Generic;

namespace DrinksVendingMachine.Interfaces.Services
{
   public interface IBaseService<T>
   {
      T Get(int id);
      void Delete(int id);
      void Save(T model);
      IEnumerable<T> GetAll();
   }
}
